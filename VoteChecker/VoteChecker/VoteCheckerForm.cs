using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace VoteChecker
{
    public partial class VoteCheckerForm : Form
    {

        private Configuration _configuration = null;
        private MySqlConnection _sqlConnection = null;
        private string _lastCode = string.Empty;



        public VoteCheckerForm()
        {
            InitializeComponent();
            LoadConfiguration();
            SetUpConnection();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
            if (_lastCode.Equals(textBox_barcode.Text))
            {
                label_attention.Visible = true;
            }
            else
            {
                label_attention.Visible = false;
            }

            _sqlConnection.Open();
            var command = _sqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM Barcodes WHERE Barcode = @barcode";
            command.Parameters.AddWithValue("@barcode", textBox_barcode.Text);
            command.Prepare();
            var result = command.ExecuteReader();


            // Get first value
            if (result.Read())
            {
                label_status.Visible = true;


                // Paste database result in struct to avoid MySQL Connection Errors
                var row = new DatabaseRow()
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
                    pictureBox_barcode.Image = GenCode128.Code128Rendering.MakeBarcodeImage(textBox_barcode.Text, 1, true);
                }
                /*
                 * Already checked:
                 * Barcode has been checked in the past
                 */
                else
                {
                    label_status.Text = "Invalid";
                    this.BackColor = Color.Red;
                    pictureBox_barcode.Image = GenCode128.Code128Rendering.MakeBarcodeImage(textBox_barcode.Text, 1, true);
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
                pictureBox_barcode.Image = GenCode128.Code128Rendering.MakeBarcodeImage(textBox_barcode.Text, 1, true);
            }
            label_barcodeOutput.Text = textBox_barcode.Text;

            var ballotCounter = int.Parse(textBox_ballot.Text);
            ballotCounter++;
            textBox_ballot.Text = ballotCounter.ToString();

            textBox_barcode.Text = string.Empty;
            textBox_barcode.Focus();
            _sqlConnection.Close();
        }

        private void LoadConfiguration()
        {
            try
            {
                XmlSerializer serialiser = new XmlSerializer(typeof(Configuration));
                _configuration = (Configuration)serialiser.Deserialize(File.OpenRead("Configuration.xml"));
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
            var command = _sqlConnection.CreateCommand();
            command.CommandText = "UPDATE Barcodes SET Checked = '1', Group_Number = @group, Packet = @packet, Item = @ballot WHERE Barcode = @barcode";

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

        private void button_NextPackage_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Next Package?", "Package", MessageBoxButtons.YesNo);

            if (answer.Equals(DialogResult.Yes))
            {
                var counter = int.Parse(textBox_packet.Text);
                counter++;
                textBox_packet.Text = counter.ToString();
                textBox_barcode.Focus();
            }

        }
    }
}
