﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using GenCode128;
using MySql.Data.MySqlClient;

namespace VoteChecker
{
    public partial class VoteCheckerForm : Form
    {
        private readonly string _lastCode = string.Empty;
        private Configuration _configuration;
        private MySqlConnection _sqlConnection;


        public VoteCheckerForm()
        {
            InitializeComponent();
            LoadConfiguration();
            SetUpConnection();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
        }


        private void CheckForEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                CheckLogic();
            }
        }

        private void CheckLogic()
        {
            label_attention.Visible = _lastCode.Equals(textBox_barcode.Text);

            _sqlConnection.Open();
            MySqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM Barcodes WHERE Barcode = @barcode";
            command.Parameters.AddWithValue("@barcode", textBox_barcode.Text);
            command.Prepare();
            MySqlDataReader result = command.ExecuteReader();


            // Get first value
            if (result.Read())
            {
                label_status.Visible = true;


                // Paste database result in struct to avoid MySQL Connection Errors
                var row = new DatabaseRow
                              {
                                  Barcode = result[0].ToString(),
                                  Checked = Boolean.Parse(result[1].ToString()),
                                  Group = result[2].ToString(),
                                  Packet = int.Parse(result[3].ToString()),
                                  Ballot = int.Parse(result[4].ToString()),
                                  TimeStamp = result[5].ToString()
                              };

                _sqlConnection.Close();


                /**
                 * Not Checked:
                 * Valid Barcode, not yet checked
                 */
                if (row.Checked.Equals(false))
                {
                    groupBox_invalid.Visible = false;

                    label_status.Text = "Valid";
                    BackColor = Color.Green;
                    SetBarcodeChecked(textBox_barcode.Text);
                    pictureBox_barcode.Image = Code128Rendering.MakeBarcodeImage(textBox_barcode.Text, 1, true);
                }
                    /*
                 * Already checked:
                 * Barcode has been checked in the past
                 */
                else
                {
                    label_status.Text = "Invalid";
                    BackColor = Color.Red;
                    pictureBox_barcode.Image = Code128Rendering.MakeBarcodeImage(textBox_barcode.Text, 1, true);
                    textBox_InvalidGroup.Text = row.Group;
                    textBox_InvalidPacket.Text = row.Packet.ToString();
                    textBox_InvalidBallot.Text = row.Ballot.ToString();
                    textBox_InvalidTime.Text = row.TimeStamp;

                    groupBox_invalid.Visible = true;
                }
            }
                /* *
             * No value returned
             * In this case the barcode has been either faulty scanned
             * OR
             * a plausible self-made copy (self-generated Barcode)
             */
            else
            {
                label_status.Text = "Unkown";
                BackColor = Color.Yellow;
                pictureBox_barcode.Image = Code128Rendering.MakeBarcodeImage(textBox_barcode.Text, 1, true);
            }
            label_barcodeOutput.Text = textBox_barcode.Text;

            int ballotCounter = int.Parse(textBox_ballot.Text);
            ballotCounter++;
            textBox_ballot.Text = ballotCounter.ToString();

            if (ballotCounter == _configuration.Limit)
            {
                NextPackageDialog();
            }

            textBox_barcode.Text = string.Empty;
            textBox_barcode.Focus();
            _sqlConnection.Close();
        }

        private void LoadConfiguration()
        {
            try
            {
                var serialiser = new XmlSerializer(typeof (Configuration));
                _configuration = (Configuration) serialiser.Deserialize(File.OpenRead("Configuration.xml"));
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load Configuration", "Error", MessageBoxButtons.OK);
                Environment.Exit(-1);
            }


            textBox_group.Text = _configuration.Group.ToString();
        }

        private void SetBarcodeChecked(string barcode)
        {
            _sqlConnection.Open();
            MySqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText =
                "UPDATE Barcodes SET Checked = '1', Group_Number = @group, Packet = @packet, Item = @ballot WHERE Barcode = @barcode";

            command.Prepare();
            command.Parameters.AddWithValue("@group", textBox_group.Text);
            command.Parameters.AddWithValue("@packet", textBox_packet.Text);
            command.Parameters.AddWithValue("@ballot", textBox_ballot.Text);
            command.Parameters.AddWithValue("@barcode", barcode);


            command.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        private void SetUpConnection()
        {
            string conString = "SERVER=" + _configuration.DatabaseIP + ";" +
                               "DATABASE=Barcodes;" +
                               "UID=" + _configuration.DatabaseUser +
                               ";PASSWORD=" + _configuration.DatabasePW + ";";

            _sqlConnection = new MySqlConnection(conString);
            try
            {
                _sqlConnection.Open();
                _sqlConnection.Ping();
            }
            catch (Exception)
            {
                MessageBox.Show("Can't establish connection to Database", "Error", MessageBoxButtons.OK);
                //Environment.Exit(-1);
            }
            _sqlConnection.Close();
        }

        private void ButtonNextPackageClick(object sender, EventArgs e)
        {
            NextPackageDialog();
        }

        private void NextPackageDialog()
        {
            DialogResult answer = MessageBox.Show("Next Package?", "Package", MessageBoxButtons.YesNo);

            if (!answer.Equals(DialogResult.Yes)) return;

            int counter = int.Parse(textBox_packet.Text);
            counter++;
            textBox_packet.Text = counter.ToString();
            textBox_ballot.Text = "0";
            textBox_barcode.Focus();
        }
    }
}