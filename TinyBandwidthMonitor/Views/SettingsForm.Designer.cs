namespace Agama
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.lblDefault = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbAutoStart = new System.Windows.Forms.CheckBox();
            this.cmbDefaultNetwork = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblColorScheme = new System.Windows.Forms.Label();
            this.txtUpdateInterval = new System.Windows.Forms.TextBox();
            this.pbColorDownload = new System.Windows.Forms.PictureBox();
            this.pbColorUpload = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUpdateInterval = new System.Windows.Forms.Label();
            this.lblChartTicks = new System.Windows.Forms.Label();
            this.txtChartTicks = new System.Windows.Forms.TextBox();
            this.cmbColorScheme = new System.Windows.Forms.ComboBox();
            this.lblWindowOpacity = new System.Windows.Forms.Label();
            this.txtWindowOpacity = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbColorDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColorUpload)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDefault
            // 
            this.lblDefault.AutoSize = true;
            this.lblDefault.Location = new System.Drawing.Point(10, 15);
            this.lblDefault.Name = "lblDefault";
            this.lblDefault.Size = new System.Drawing.Size(82, 13);
            this.lblDefault.TabIndex = 0;
            this.lblDefault.Text = "Default network";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(233, 174);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbAutoStart
            // 
            this.cbAutoStart.AutoSize = true;
            this.cbAutoStart.Location = new System.Drawing.Point(12, 178);
            this.cbAutoStart.Name = "cbAutoStart";
            this.cbAutoStart.Size = new System.Drawing.Size(134, 17);
            this.cbAutoStart.TabIndex = 6;
            this.cbAutoStart.Text = "Run at Windows logon";
            this.cbAutoStart.UseVisualStyleBackColor = true;
            this.cbAutoStart.Visible = false;
            // 
            // cmbDefaultNetwork
            // 
            this.cmbDefaultNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefaultNetwork.FormattingEnabled = true;
            this.cmbDefaultNetwork.Items.AddRange(new object[] {
            "Automatic"});
            this.cmbDefaultNetwork.Location = new System.Drawing.Point(119, 12);
            this.cmbDefaultNetwork.Name = "cmbDefaultNetwork";
            this.cmbDefaultNetwork.Size = new System.Drawing.Size(189, 21);
            this.cmbDefaultNetwork.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(152, 174);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblColorScheme
            // 
            this.lblColorScheme.AutoSize = true;
            this.lblColorScheme.Location = new System.Drawing.Point(10, 119);
            this.lblColorScheme.Name = "lblColorScheme";
            this.lblColorScheme.Size = new System.Drawing.Size(71, 13);
            this.lblColorScheme.TabIndex = 6;
            this.lblColorScheme.Text = "Color scheme";
            // 
            // txtUpdateInterval
            // 
            this.txtUpdateInterval.Location = new System.Drawing.Point(119, 38);
            this.txtUpdateInterval.Name = "txtUpdateInterval";
            this.txtUpdateInterval.Size = new System.Drawing.Size(58, 20);
            this.txtUpdateInterval.TabIndex = 2;
            this.txtUpdateInterval.Text = "100";
            this.txtUpdateInterval.Leave += new System.EventHandler(this.txtUpdateInterval_Leave);
            // 
            // pbColorDownload
            // 
            this.pbColorDownload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbColorDownload.Location = new System.Drawing.Point(119, 143);
            this.pbColorDownload.Name = "pbColorDownload";
            this.pbColorDownload.Size = new System.Drawing.Size(21, 21);
            this.pbColorDownload.TabIndex = 9;
            this.pbColorDownload.TabStop = false;
            this.pbColorDownload.Click += new System.EventHandler(this.pbColorDownload_Click);
            // 
            // pbColorUpload
            // 
            this.pbColorUpload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbColorUpload.Location = new System.Drawing.Point(219, 143);
            this.pbColorUpload.Name = "pbColorUpload";
            this.pbColorUpload.Size = new System.Drawing.Size(21, 21);
            this.pbColorUpload.TabIndex = 10;
            this.pbColorUpload.TabStop = false;
            this.pbColorUpload.Click += new System.EventHandler(this.pbColorUpload_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Download";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Upload";
            // 
            // lblUpdateInterval
            // 
            this.lblUpdateInterval.AutoSize = true;
            this.lblUpdateInterval.Location = new System.Drawing.Point(9, 41);
            this.lblUpdateInterval.Name = "lblUpdateInterval";
            this.lblUpdateInterval.Size = new System.Drawing.Size(101, 13);
            this.lblUpdateInterval.TabIndex = 13;
            this.lblUpdateInterval.Text = "Update interval [ms]";
            // 
            // lblChartTicks
            // 
            this.lblChartTicks.AutoSize = true;
            this.lblChartTicks.Location = new System.Drawing.Point(10, 67);
            this.lblChartTicks.Name = "lblChartTicks";
            this.lblChartTicks.Size = new System.Drawing.Size(87, 13);
            this.lblChartTicks.TabIndex = 15;
            this.lblChartTicks.Text = "Chart ticks count";
            // 
            // txtChartTicks
            // 
            this.txtChartTicks.Location = new System.Drawing.Point(119, 64);
            this.txtChartTicks.Name = "txtChartTicks";
            this.txtChartTicks.Size = new System.Drawing.Size(58, 20);
            this.txtChartTicks.TabIndex = 3;
            this.txtChartTicks.Text = "1000";
            this.txtChartTicks.Leave += new System.EventHandler(this.txtChartTicks_Leave);
            // 
            // cmbColorScheme
            // 
            this.cmbColorScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColorScheme.FormattingEnabled = true;
            this.cmbColorScheme.Items.AddRange(new object[] {
            "Blue + Yellow",
            "Red + Green",
            "Custom"});
            this.cmbColorScheme.Location = new System.Drawing.Point(119, 116);
            this.cmbColorScheme.Name = "cmbColorScheme";
            this.cmbColorScheme.Size = new System.Drawing.Size(189, 21);
            this.cmbColorScheme.TabIndex = 5;
            this.cmbColorScheme.SelectedIndexChanged += new System.EventHandler(this.cmbColorScheme_SelectedIndexChanged);
            // 
            // lblWindowOpacity
            // 
            this.lblWindowOpacity.AutoSize = true;
            this.lblWindowOpacity.Location = new System.Drawing.Point(9, 93);
            this.lblWindowOpacity.Name = "lblWindowOpacity";
            this.lblWindowOpacity.Size = new System.Drawing.Size(83, 13);
            this.lblWindowOpacity.TabIndex = 18;
            this.lblWindowOpacity.Text = "Window opacity";
            // 
            // txtWindowOpacity
            // 
            this.txtWindowOpacity.Location = new System.Drawing.Point(119, 90);
            this.txtWindowOpacity.Name = "txtWindowOpacity";
            this.txtWindowOpacity.Size = new System.Drawing.Size(58, 20);
            this.txtWindowOpacity.TabIndex = 4;
            this.txtWindowOpacity.Text = "100%";
            this.txtWindowOpacity.Leave += new System.EventHandler(this.txtWindowOpacity_Leave);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(320, 208);
            this.Controls.Add(this.lblWindowOpacity);
            this.Controls.Add(this.txtWindowOpacity);
            this.Controls.Add(this.cmbColorScheme);
            this.Controls.Add(this.lblChartTicks);
            this.Controls.Add(this.txtChartTicks);
            this.Controls.Add(this.lblUpdateInterval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbColorUpload);
            this.Controls.Add(this.pbColorDownload);
            this.Controls.Add(this.txtUpdateInterval);
            this.Controls.Add(this.lblColorScheme);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbDefaultNetwork);
            this.Controls.Add(this.cbAutoStart);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDefault);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.pbColorDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColorUpload)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDefault;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbAutoStart;
        private System.Windows.Forms.ComboBox cmbDefaultNetwork;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblColorScheme;
        private System.Windows.Forms.TextBox txtUpdateInterval;
        private System.Windows.Forms.PictureBox pbColorDownload;
        private System.Windows.Forms.PictureBox pbColorUpload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUpdateInterval;
        private System.Windows.Forms.Label lblChartTicks;
        private System.Windows.Forms.TextBox txtChartTicks;
        private System.Windows.Forms.ComboBox cmbColorScheme;
        private System.Windows.Forms.Label lblWindowOpacity;
        private System.Windows.Forms.TextBox txtWindowOpacity;
    }
}