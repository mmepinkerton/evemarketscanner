namespace MarketScanner
{
    partial class StarSystemsFilter
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
            this.tbSystemToAdd = new System.Windows.Forms.TextBox();
            this.bAddSystem = new System.Windows.Forms.Button();
            this.lbExeptedSystems = new System.Windows.Forms.ListBox();
            this.bRemoveSelected = new System.Windows.Forms.Button();
            this.bCloseAndSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbSystemToAdd
            // 
            this.tbSystemToAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSystemToAdd.Location = new System.Drawing.Point( 12, 12 );
            this.tbSystemToAdd.Name = "tbSystemToAdd";
            this.tbSystemToAdd.Size = new System.Drawing.Size( 211, 20 );
            this.tbSystemToAdd.TabIndex = 0;
            // 
            // bAddSystem
            // 
            this.bAddSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAddSystem.Location = new System.Drawing.Point( 229, 10 );
            this.bAddSystem.Name = "bAddSystem";
            this.bAddSystem.Size = new System.Drawing.Size( 51, 23 );
            this.bAddSystem.TabIndex = 1;
            this.bAddSystem.Text = "Add";
            this.bAddSystem.UseVisualStyleBackColor = true;
            this.bAddSystem.Click += new System.EventHandler( this.bAddSystem_Click );
            // 
            // lbExeptedSystems
            // 
            this.lbExeptedSystems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbExeptedSystems.FormattingEnabled = true;
            this.lbExeptedSystems.Location = new System.Drawing.Point( 12, 43 );
            this.lbExeptedSystems.Name = "lbExeptedSystems";
            this.lbExeptedSystems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbExeptedSystems.Size = new System.Drawing.Size( 268, 186 );
            this.lbExeptedSystems.TabIndex = 2;
            // 
            // bRemoveSelected
            // 
            this.bRemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bRemoveSelected.Location = new System.Drawing.Point( 90, 235 );
            this.bRemoveSelected.Name = "bRemoveSelected";
            this.bRemoveSelected.Size = new System.Drawing.Size( 98, 23 );
            this.bRemoveSelected.TabIndex = 3;
            this.bRemoveSelected.Text = "Remove selected";
            this.bRemoveSelected.UseVisualStyleBackColor = true;
            this.bRemoveSelected.Click += new System.EventHandler( this.bRemoveSelected_Click );
            // 
            // bCloseAndSave
            // 
            this.bCloseAndSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCloseAndSave.Location = new System.Drawing.Point( 194, 235 );
            this.bCloseAndSave.Name = "bCloseAndSave";
            this.bCloseAndSave.Size = new System.Drawing.Size( 86, 23 );
            this.bCloseAndSave.TabIndex = 4;
            this.bCloseAndSave.Text = "Save && Close";
            this.bCloseAndSave.UseVisualStyleBackColor = true;
            this.bCloseAndSave.Click += new System.EventHandler( this.bCloseAndSave_Click );
            // 
            // StarSystemsFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 292, 266 );
            this.Controls.Add( this.bCloseAndSave );
            this.Controls.Add( this.bRemoveSelected );
            this.Controls.Add( this.lbExeptedSystems );
            this.Controls.Add( this.bAddSystem );
            this.Controls.Add( this.tbSystemToAdd );
            this.Name = "StarSystemsFilter";
            this.Text = "Exclude systems";
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSystemToAdd;
        private System.Windows.Forms.Button bAddSystem;
        private System.Windows.Forms.ListBox lbExeptedSystems;
        private System.Windows.Forms.Button bRemoveSelected;
        private System.Windows.Forms.Button bCloseAndSave;
    }
}