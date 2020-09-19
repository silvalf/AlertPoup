namespace AlertPoup
{
    partial class frmTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMaxAlertsVisible = new System.Windows.Forms.Label();
            this.lblMaxSecondsVisible = new System.Windows.Forms.Label();
            this.txtMaxAlertsVisible = new System.Windows.Forms.TextBox();
            this.txtMaxSecondsVisible = new System.Windows.Forms.TextBox();
            this.trackMaxAlertsVisible = new System.Windows.Forms.TrackBar();
            this.trackMaxSecondsVisible = new System.Windows.Forms.TrackBar();
            this.rdoShowBottom = new System.Windows.Forms.RadioButton();
            this.rdoShoTop = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.chkAutoManageQueue = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackMaxAlertsVisible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMaxSecondsVisible)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(18, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Info";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkOrange;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(246, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(222, 47);
            this.button2.TabIndex = 1;
            this.button2.Text = "Warning";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkRed;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(246, 255);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(222, 47);
            this.button3.TabIndex = 2;
            this.button3.Text = "Error";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.SeaGreen;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(18, 202);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(222, 47);
            this.button4.TabIndex = 2;
            this.button4.Text = "Success";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAutoManageQueue);
            this.groupBox1.Controls.Add(this.lblMaxAlertsVisible);
            this.groupBox1.Controls.Add(this.lblMaxSecondsVisible);
            this.groupBox1.Controls.Add(this.txtMaxAlertsVisible);
            this.groupBox1.Controls.Add(this.txtMaxSecondsVisible);
            this.groupBox1.Controls.Add(this.trackMaxAlertsVisible);
            this.groupBox1.Controls.Add(this.trackMaxSecondsVisible);
            this.groupBox1.Controls.Add(this.rdoShowBottom);
            this.groupBox1.Controls.Add(this.rdoShoTop);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 140);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configure Alert";
            // 
            // lblMaxAlertsVisible
            // 
            this.lblMaxAlertsVisible.AutoSize = true;
            this.lblMaxAlertsVisible.Location = new System.Drawing.Point(147, 99);
            this.lblMaxAlertsVisible.Name = "lblMaxAlertsVisible";
            this.lblMaxAlertsVisible.Size = new System.Drawing.Size(179, 13);
            this.lblMaxAlertsVisible.TabIndex = 7;
            this.lblMaxAlertsVisible.Text = "Max alerts visible (min. 0 - max x)";
            // 
            // lblMaxSecondsVisible
            // 
            this.lblMaxSecondsVisible.AutoSize = true;
            this.lblMaxSecondsVisible.Location = new System.Drawing.Point(147, 70);
            this.lblMaxSecondsVisible.Name = "lblMaxSecondsVisible";
            this.lblMaxSecondsVisible.Size = new System.Drawing.Size(199, 13);
            this.lblMaxSecondsVisible.TabIndex = 6;
            this.lblMaxSecondsVisible.Text = "Max Seconds Visible  (min. 1 - max 10)";
            // 
            // txtMaxAlertsVisible
            // 
            this.txtMaxAlertsVisible.Location = new System.Drawing.Point(6, 95);
            this.txtMaxAlertsVisible.Name = "txtMaxAlertsVisible";
            this.txtMaxAlertsVisible.Size = new System.Drawing.Size(25, 22);
            this.txtMaxAlertsVisible.TabIndex = 5;
            this.txtMaxAlertsVisible.Text = "1";
            this.txtMaxAlertsVisible.TextChanged += new System.EventHandler(this.txtMaxAlertsVisible_TextChanged);
            // 
            // txtMaxSecondsVisible
            // 
            this.txtMaxSecondsVisible.Location = new System.Drawing.Point(6, 67);
            this.txtMaxSecondsVisible.Name = "txtMaxSecondsVisible";
            this.txtMaxSecondsVisible.Size = new System.Drawing.Size(25, 22);
            this.txtMaxSecondsVisible.TabIndex = 4;
            this.txtMaxSecondsVisible.Text = "1";
            this.txtMaxSecondsVisible.TextChanged += new System.EventHandler(this.txtMaxSecondsVisible_TextChanged);
            // 
            // trackMaxAlertsVisible
            // 
            this.trackMaxAlertsVisible.AutoSize = false;
            this.trackMaxAlertsVisible.Location = new System.Drawing.Point(37, 97);
            this.trackMaxAlertsVisible.Maximum = 100;
            this.trackMaxAlertsVisible.Minimum = 1;
            this.trackMaxAlertsVisible.Name = "trackMaxAlertsVisible";
            this.trackMaxAlertsVisible.Size = new System.Drawing.Size(104, 24);
            this.trackMaxAlertsVisible.TabIndex = 3;
            this.trackMaxAlertsVisible.Value = 1;
            this.trackMaxAlertsVisible.ValueChanged += new System.EventHandler(this.trackMaxAlertsVisible_ValueChanged);
            // 
            // trackMaxSecondsVisible
            // 
            this.trackMaxSecondsVisible.AutoSize = false;
            this.trackMaxSecondsVisible.Location = new System.Drawing.Point(37, 67);
            this.trackMaxSecondsVisible.Minimum = 1;
            this.trackMaxSecondsVisible.Name = "trackMaxSecondsVisible";
            this.trackMaxSecondsVisible.Size = new System.Drawing.Size(104, 24);
            this.trackMaxSecondsVisible.TabIndex = 2;
            this.trackMaxSecondsVisible.Value = 1;
            this.trackMaxSecondsVisible.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // rdoShowBottom
            // 
            this.rdoShowBottom.AutoSize = true;
            this.rdoShowBottom.Location = new System.Drawing.Point(96, 35);
            this.rdoShowBottom.Name = "rdoShowBottom";
            this.rdoShowBottom.Size = new System.Drawing.Size(94, 17);
            this.rdoShowBottom.TabIndex = 1;
            this.rdoShowBottom.TabStop = true;
            this.rdoShowBottom.Text = "Show Bottom";
            this.rdoShowBottom.UseVisualStyleBackColor = true;
            // 
            // rdoShoTop
            // 
            this.rdoShoTop.AutoSize = true;
            this.rdoShoTop.Location = new System.Drawing.Point(16, 35);
            this.rdoShoTop.Name = "rdoShoTop";
            this.rdoShoTop.Size = new System.Drawing.Size(74, 17);
            this.rdoShoTop.TabIndex = 0;
            this.rdoShoTop.TabStop = true;
            this.rdoShoTop.Text = "Show Top";
            this.rdoShoTop.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(207, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Test Alert";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(18, 351);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(440, 45);
            this.txtMessage.TabIndex = 5;
            this.txtMessage.Text = " Message teste, loreipn is best site ";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(21, 334);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(52, 13);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "Message";
            // 
            // chkAutoManageQueue
            // 
            this.chkAutoManageQueue.AutoSize = true;
            this.chkAutoManageQueue.Enabled = false;
            this.chkAutoManageQueue.Location = new System.Drawing.Point(234, 35);
            this.chkAutoManageQueue.Name = "chkAutoManageQueue";
            this.chkAutoManageQueue.Size = new System.Drawing.Size(128, 17);
            this.chkAutoManageQueue.TabIndex = 8;
            this.chkAutoManageQueue.Text = "Auto manage queue";
            this.chkAutoManageQueue.UseVisualStyleBackColor = true;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 455);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.Name = "frmTest";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackMaxAlertsVisible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMaxSecondsVisible)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMaxAlertsVisible;
        private System.Windows.Forms.Label lblMaxSecondsVisible;
        private System.Windows.Forms.TextBox txtMaxAlertsVisible;
        private System.Windows.Forms.TextBox txtMaxSecondsVisible;
        private System.Windows.Forms.TrackBar trackMaxAlertsVisible;
        private System.Windows.Forms.TrackBar trackMaxSecondsVisible;
        private System.Windows.Forms.RadioButton rdoShowBottom;
        private System.Windows.Forms.RadioButton rdoShoTop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.CheckBox chkAutoManageQueue;
    }
}

