namespace VoteChecker
{
    partial class VoteCheckerForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoteCheckerForm));
            this.textBox_barcode = new System.Windows.Forms.TextBox();
            this.label_status = new System.Windows.Forms.Label();
            this.pictureBox_barcode = new System.Windows.Forms.PictureBox();
            this.label_barcodeOutput = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_ballot = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_packet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_group = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_NextPackage = new System.Windows.Forms.Button();
            this.groupBox_invalid = new System.Windows.Forms.GroupBox();
            this.textBox_InvalidTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_InvalidBallot = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_InvalidPacket = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_InvalidGroup = new System.Windows.Forms.TextBox();
            this.label_attention = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_barcode)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox_invalid.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_barcode
            // 
            this.textBox_barcode.Location = new System.Drawing.Point(529, 244);
            this.textBox_barcode.Name = "textBox_barcode";
            this.textBox_barcode.Size = new System.Drawing.Size(169, 20);
            this.textBox_barcode.TabIndex = 0;
            this.textBox_barcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckForEnter);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.Location = new System.Drawing.Point(472, 112);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(295, 108);
            this.label_status.TabIndex = 1;
            this.label_status.Text = "Gültig";
            this.label_status.Visible = false;
            // 
            // pictureBox_barcode
            // 
            this.pictureBox_barcode.Location = new System.Drawing.Point(465, 297);
            this.pictureBox_barcode.Name = "pictureBox_barcode";
            this.pictureBox_barcode.Size = new System.Drawing.Size(302, 56);
            this.pictureBox_barcode.TabIndex = 2;
            this.pictureBox_barcode.TabStop = false;
            // 
            // label_barcodeOutput
            // 
            this.label_barcodeOutput.AutoSize = true;
            this.label_barcodeOutput.Location = new System.Drawing.Point(564, 380);
            this.label_barcodeOutput.Name = "label_barcodeOutput";
            this.label_barcodeOutput.Size = new System.Drawing.Size(16, 13);
            this.label_barcodeOutput.TabIndex = 3;
            this.label_barcodeOutput.Text = "...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_ballot);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_packet);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_group);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_NextPackage);
            this.groupBox1.Location = new System.Drawing.Point(277, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 53);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Group";
            // 
            // textBox_ballot
            // 
            this.textBox_ballot.Enabled = false;
            this.textBox_ballot.Location = new System.Drawing.Point(363, 20);
            this.textBox_ballot.Name = "textBox_ballot";
            this.textBox_ballot.Size = new System.Drawing.Size(95, 20);
            this.textBox_ballot.TabIndex = 6;
            this.textBox_ballot.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ballot:";
            // 
            // textBox_packet
            // 
            this.textBox_packet.Enabled = false;
            this.textBox_packet.Location = new System.Drawing.Point(208, 20);
            this.textBox_packet.Name = "textBox_packet";
            this.textBox_packet.Size = new System.Drawing.Size(95, 20);
            this.textBox_packet.TabIndex = 4;
            this.textBox_packet.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Packet:";
            // 
            // textBox_group
            // 
            this.textBox_group.Enabled = false;
            this.textBox_group.Location = new System.Drawing.Point(56, 20);
            this.textBox_group.Name = "textBox_group";
            this.textBox_group.Size = new System.Drawing.Size(95, 20);
            this.textBox_group.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Group:";
            // 
            // button_NextPackage
            // 
            this.button_NextPackage.Location = new System.Drawing.Point(477, 15);
            this.button_NextPackage.Name = "button_NextPackage";
            this.button_NextPackage.Size = new System.Drawing.Size(145, 28);
            this.button_NextPackage.TabIndex = 0;
            this.button_NextPackage.Text = "Nächstes Paket";
            this.button_NextPackage.UseVisualStyleBackColor = true;
            this.button_NextPackage.Click += new System.EventHandler(this.button_NextPackage_Click);
            // 
            // groupBox_invalid
            // 
            this.groupBox_invalid.Controls.Add(this.textBox_InvalidTime);
            this.groupBox_invalid.Controls.Add(this.label7);
            this.groupBox_invalid.Controls.Add(this.textBox_InvalidBallot);
            this.groupBox_invalid.Controls.Add(this.label6);
            this.groupBox_invalid.Controls.Add(this.textBox_InvalidPacket);
            this.groupBox_invalid.Controls.Add(this.label5);
            this.groupBox_invalid.Controls.Add(this.label3);
            this.groupBox_invalid.Controls.Add(this.textBox_InvalidGroup);
            this.groupBox_invalid.Location = new System.Drawing.Point(357, 543);
            this.groupBox_invalid.Name = "groupBox_invalid";
            this.groupBox_invalid.Size = new System.Drawing.Size(507, 50);
            this.groupBox_invalid.TabIndex = 5;
            this.groupBox_invalid.TabStop = false;
            this.groupBox_invalid.Text = "Invalid";
            this.groupBox_invalid.Visible = false;
            // 
            // textBox_InvalidTime
            // 
            this.textBox_InvalidTime.Enabled = false;
            this.textBox_InvalidTime.Location = new System.Drawing.Point(343, 17);
            this.textBox_InvalidTime.Name = "textBox_InvalidTime";
            this.textBox_InvalidTime.Size = new System.Drawing.Size(157, 20);
            this.textBox_InvalidTime.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(304, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Time:";
            // 
            // textBox_InvalidBallot
            // 
            this.textBox_InvalidBallot.Enabled = false;
            this.textBox_InvalidBallot.Location = new System.Drawing.Point(250, 17);
            this.textBox_InvalidBallot.Name = "textBox_InvalidBallot";
            this.textBox_InvalidBallot.Size = new System.Drawing.Size(47, 20);
            this.textBox_InvalidBallot.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ballot:";
            // 
            // textBox_InvalidPacket
            // 
            this.textBox_InvalidPacket.Enabled = false;
            this.textBox_InvalidPacket.Location = new System.Drawing.Point(155, 17);
            this.textBox_InvalidPacket.Name = "textBox_InvalidPacket";
            this.textBox_InvalidPacket.Size = new System.Drawing.Size(47, 20);
            this.textBox_InvalidPacket.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Packet:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Group:";
            // 
            // textBox_InvalidGroup
            // 
            this.textBox_InvalidGroup.Enabled = false;
            this.textBox_InvalidGroup.Location = new System.Drawing.Point(52, 17);
            this.textBox_InvalidGroup.Name = "textBox_InvalidGroup";
            this.textBox_InvalidGroup.Size = new System.Drawing.Size(47, 20);
            this.textBox_InvalidGroup.TabIndex = 1;
            // 
            // label_attention
            // 
            this.label_attention.AutoSize = true;
            this.label_attention.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_attention.Location = new System.Drawing.Point(869, 231);
            this.label_attention.Name = "label_attention";
            this.label_attention.Size = new System.Drawing.Size(72, 108);
            this.label_attention.TabIndex = 6;
            this.label_attention.Text = "!";
            this.label_attention.Visible = false;
            // 
            // VoteCheckerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 772);
            this.Controls.Add(this.label_attention);
            this.Controls.Add(this.groupBox_invalid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_barcodeOutput);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.pictureBox_barcode);
            this.Controls.Add(this.textBox_barcode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VoteCheckerForm";
            this.Text = "VoteChecker";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_barcode)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_invalid.ResumeLayout(false);
            this.groupBox_invalid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_barcode;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.PictureBox pictureBox_barcode;
        private System.Windows.Forms.Label label_barcodeOutput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_packet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_group;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_NextPackage;
        private System.Windows.Forms.TextBox textBox_ballot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox_invalid;
        private System.Windows.Forms.TextBox textBox_InvalidTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_InvalidBallot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_InvalidPacket;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_InvalidGroup;
        private System.Windows.Forms.Label label_attention;
    }
}

