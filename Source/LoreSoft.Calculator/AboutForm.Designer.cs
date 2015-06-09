namespace LoreSoft.Calculator
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.assembliesListView = new System.Windows.Forms.ListView();
            this.assemblyColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.versionColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.dateColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.loresoftLinkLabel = new System.Windows.Forms.LinkLabel();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.versionGroupBox = new System.Windows.Forms.GroupBox();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.versionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // assembliesListView
            // 
            this.assembliesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.assemblyColumnHeader,
            this.versionColumnHeader,
            this.dateColumnHeader});
            this.assembliesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.assembliesListView.Location = new System.Drawing.Point(8, 16);
            this.assembliesListView.Name = "assembliesListView";
            this.assembliesListView.Size = new System.Drawing.Size(384, 120);
            this.assembliesListView.TabIndex = 9;
            this.assembliesListView.UseCompatibleStateImageBehavior = false;
            this.assembliesListView.View = System.Windows.Forms.View.Details;
            // 
            // assemblyColumnHeader
            // 
            this.assemblyColumnHeader.Text = "Module";
            this.assemblyColumnHeader.Width = 160;
            // 
            // versionColumnHeader
            // 
            this.versionColumnHeader.Text = "Version";
            this.versionColumnHeader.Width = 105;
            // 
            // dateColumnHeader
            // 
            this.dateColumnHeader.Text = "Date";
            this.dateColumnHeader.Width = 95;
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.copyrightLabel.Location = new System.Drawing.Point(121, 57);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(273, 23);
            this.copyrightLabel.TabIndex = 22;
            this.copyrightLabel.Text = "Application Copyright";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.descriptionLabel.Location = new System.Drawing.Point(121, 81);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(273, 32);
            this.descriptionLabel.TabIndex = 21;
            this.descriptionLabel.Text = "Application Description";
            // 
            // versionLabel
            // 
            this.versionLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.versionLabel.Location = new System.Drawing.Point(121, 33);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(273, 23);
            this.versionLabel.TabIndex = 20;
            this.versionLabel.Text = "Application Version";
            // 
            // titleLabel
            // 
            this.titleLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.titleLabel.Location = new System.Drawing.Point(121, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(273, 24);
            this.titleLabel.TabIndex = 19;
            this.titleLabel.Text = "Application Title";
            // 
            // loresoftLinkLabel
            // 
            this.loresoftLinkLabel.Location = new System.Drawing.Point(121, 113);
            this.loresoftLinkLabel.Name = "loresoftLinkLabel";
            this.loresoftLinkLabel.Size = new System.Drawing.Size(273, 23);
            this.loresoftLinkLabel.TabIndex = 23;
            this.loresoftLinkLabel.TabStop = true;
            this.loresoftLinkLabel.Text = "http://www.loresoft.com";
            this.loresoftLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.loresoftLinkLabel_LinkClicked);
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Image = global::LoreSoft.Calculator.Properties.Resources.Calculator96;
            this.iconPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.iconPictureBox.Location = new System.Drawing.Point(10, 9);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(96, 96);
            this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iconPictureBox.TabIndex = 18;
            this.iconPictureBox.TabStop = false;
            // 
            // versionGroupBox
            // 
            this.versionGroupBox.Controls.Add(this.assembliesListView);
            this.versionGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.versionGroupBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.versionGroupBox.Location = new System.Drawing.Point(2, 137);
            this.versionGroupBox.Name = "versionGroupBox";
            this.versionGroupBox.Size = new System.Drawing.Size(400, 144);
            this.versionGroupBox.TabIndex = 17;
            this.versionGroupBox.TabStop = false;
            this.versionGroupBox.Text = "Version Information";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Location = new System.Drawing.Point(322, 289);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 16;
            this.okButton.Text = "&OK";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 319);
            this.Controls.Add(this.copyrightLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.loresoftLinkLabel);
            this.Controls.Add(this.iconPictureBox);
            this.Controls.Add(this.versionGroupBox);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Calculator.NET";
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.versionGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView assembliesListView;
        private System.Windows.Forms.ColumnHeader assemblyColumnHeader;
        private System.Windows.Forms.ColumnHeader versionColumnHeader;
        private System.Windows.Forms.ColumnHeader dateColumnHeader;
        internal System.Windows.Forms.Label copyrightLabel;
        internal System.Windows.Forms.Label descriptionLabel;
        internal System.Windows.Forms.Label versionLabel;
        internal System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.LinkLabel loresoftLinkLabel;
        internal System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.GroupBox versionGroupBox;
        private System.Windows.Forms.Button okButton;

    }
}
