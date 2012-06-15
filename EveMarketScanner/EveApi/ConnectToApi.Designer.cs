namespace MarketScanner.EveApi
{
    partial class ConnectToApi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBarForFetchingData = new System.Windows.Forms.ProgressBar();
            this.cbSaveApiKey = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConnet = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point( 65, 72 );
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size( 100, 20 );
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point( 65, 98 );
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size( 426, 20 );
            this.textBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 17, 75 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 46, 13 );
            this.label1.TabIndex = 2;
            this.label1.Text = "User ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 15, 101 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 48, 13 );
            this.label2.TabIndex = 3;
            this.label2.Text = "API Key:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.linkLabel1 );
            this.groupBox1.Controls.Add( this.progressBarForFetchingData );
            this.groupBox1.Controls.Add( this.cbSaveApiKey );
            this.groupBox1.Controls.Add( this.label3 );
            this.groupBox1.Controls.Add( this.textBox1 );
            this.groupBox1.Controls.Add( this.textBox2 );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Controls.Add( this.label2 );
            this.groupBox1.Location = new System.Drawing.Point( 12, 12 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 510, 182 );
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Full Access API Key";
            // 
            // progressBarForFetchingData
            // 
            this.progressBarForFetchingData.Location = new System.Drawing.Point( 119, 147 );
            this.progressBarForFetchingData.Name = "progressBarForFetchingData";
            this.progressBarForFetchingData.Size = new System.Drawing.Size( 256, 23 );
            this.progressBarForFetchingData.TabIndex = 11;
            this.progressBarForFetchingData.Visible = false;
            // 
            // cbSaveApiKey
            // 
            this.cbSaveApiKey.AutoSize = true;
            this.cbSaveApiKey.Checked = true;
            this.cbSaveApiKey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaveApiKey.Location = new System.Drawing.Point( 65, 124 );
            this.cbSaveApiKey.Name = "cbSaveApiKey";
            this.cbSaveApiKey.Size = new System.Drawing.Size( 383, 17 );
            this.cbSaveApiKey.TabIndex = 5;
            this.cbSaveApiKey.Text = "Save User ID and API key for this account (Stored locally on your machine).";
            this.cbSaveApiKey.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 6, 28 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 369, 13 );
            this.label3.TabIndex = 4;
            this.label3.Text = "Only the full access api key will give access to wallet information. Get it Here:" +
                "";
            // 
            // btnConnet
            // 
            this.btnConnet.Location = new System.Drawing.Point( 447, 200 );
            this.btnConnet.Name = "btnConnet";
            this.btnConnet.Size = new System.Drawing.Size( 75, 23 );
            this.btnConnet.TabIndex = 9;
            this.btnConnet.Text = "Connect";
            this.btnConnet.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point( 366, 200 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point( 6, 45 );
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size( 168, 13 );
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://myeve.eve-online.com/api/";
            // 
            // ConnectToApi
            // 
            this.AcceptButton = this.btnConnet;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size( 534, 233 );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnConnet );
            this.Controls.Add( this.groupBox1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ConnectToApi";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Eve API";
            this.TopMost = true;
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConnet;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbSaveApiKey;
        private System.Windows.Forms.ProgressBar progressBarForFetchingData;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}