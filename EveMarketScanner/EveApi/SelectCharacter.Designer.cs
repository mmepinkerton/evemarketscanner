namespace MarketScanner.EveApi
{
    partial class SelectCharacter
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnSelectChar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point( 12, 12 );
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size( 208, 56 );
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler( this.listBox1_SelectedIndexChanged );
            // 
            // btnSelectChar
            // 
            this.btnSelectChar.Location = new System.Drawing.Point( 145, 74 );
            this.btnSelectChar.Name = "btnSelectChar";
            this.btnSelectChar.Size = new System.Drawing.Size( 75, 23 );
            this.btnSelectChar.TabIndex = 1;
            this.btnSelectChar.Text = "Select";
            this.btnSelectChar.UseVisualStyleBackColor = true;
            this.btnSelectChar.Click += new System.EventHandler( this.button1_Click );
            // 
            // SelectCharacter
            // 
            this.AcceptButton = this.btnSelectChar;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 232, 110 );
            this.Controls.Add( this.btnSelectChar );
            this.Controls.Add( this.listBox1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectCharacter";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SelectCharacter";
            this.TopMost = true;
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnSelectChar;
    }
}