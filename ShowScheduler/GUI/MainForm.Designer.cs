namespace ShowScheduler
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.showList = new System.Windows.Forms.ListBox();
            this.showListLabel = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.GetShowsBtn = new System.Windows.Forms.Button();
            this.configGroupBox = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cfgTenureCheck = new System.Windows.Forms.CheckBox();
            this.menuStrip.SuspendLayout();
            this.configGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // showList
            // 
            this.showList.FormattingEnabled = true;
            this.showList.Location = new System.Drawing.Point(16, 40);
            this.showList.Name = "showList";
            this.showList.Size = new System.Drawing.Size(276, 394);
            this.showList.TabIndex = 0;
            // 
            // showListLabel
            // 
            this.showListLabel.AutoSize = true;
            this.showListLabel.Location = new System.Drawing.Point(13, 24);
            this.showListLabel.Name = "showListLabel";
            this.showListLabel.Size = new System.Drawing.Size(39, 13);
            this.showListLabel.TabIndex = 1;
            this.showListLabel.Text = "Shows";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(425, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.tutorialToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // tutorialToolStripMenuItem
            // 
            this.tutorialToolStripMenuItem.Name = "tutorialToolStripMenuItem";
            this.tutorialToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.tutorialToolStripMenuItem.Text = "Tutorial";
            this.tutorialToolStripMenuItem.Click += new System.EventHandler(this.tutorialToolStripMenuItem_Click);
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.Location = new System.Drawing.Point(307, 73);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(106, 37);
            this.GenerateBtn.TabIndex = 3;
            this.GenerateBtn.Text = "Generate Schedule";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // GetShowsBtn
            // 
            this.GetShowsBtn.Location = new System.Drawing.Point(307, 40);
            this.GetShowsBtn.Name = "GetShowsBtn";
            this.GetShowsBtn.Size = new System.Drawing.Size(106, 27);
            this.GetShowsBtn.TabIndex = 4;
            this.GetShowsBtn.Text = "Get Shows";
            this.GetShowsBtn.UseVisualStyleBackColor = true;
            this.GetShowsBtn.Click += new System.EventHandler(this.GetShowsBtn_Click);
            // 
            // configGroupBox
            // 
            this.configGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configGroupBox.AutoSize = true;
            this.configGroupBox.Controls.Add(this.cfgTenureCheck);
            this.configGroupBox.Location = new System.Drawing.Point(307, 117);
            this.configGroupBox.Name = "configGroupBox";
            this.configGroupBox.Size = new System.Drawing.Size(106, 153);
            this.configGroupBox.TabIndex = 5;
            this.configGroupBox.TabStop = false;
            this.configGroupBox.Text = "configGroup";
            // 
            // cfgTenureCheck
            // 
            this.cfgTenureCheck.AutoSize = true;
            this.cfgTenureCheck.Location = new System.Drawing.Point(7, 20);
            this.cfgTenureCheck.Name = "cfgTenureCheck";
            this.cfgTenureCheck.Size = new System.Drawing.Size(88, 17);
            this.cfgTenureCheck.TabIndex = 0;
            this.cfgTenureCheck.Text = "Use Tenure?";
            this.toolTip1.SetToolTip(this.cfgTenureCheck, "Consider show tenure when scheduling");
            this.cfgTenureCheck.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 448);
            this.Controls.Add(this.configGroupBox);
            this.Controls.Add(this.GetShowsBtn);
            this.Controls.Add(this.GenerateBtn);
            this.Controls.Add(this.showListLabel);
            this.Controls.Add(this.showList);
            this.Controls.Add(this.menuStrip);
            this.Name = "MainForm";
            this.Text = "Show Scheduler";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.configGroupBox.ResumeLayout(false);
            this.configGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox showList;
        private System.Windows.Forms.Label showListLabel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tutorialToolStripMenuItem;
        private System.Windows.Forms.Button GenerateBtn;
        private System.Windows.Forms.Button GetShowsBtn;
        private System.Windows.Forms.GroupBox configGroupBox;
        private System.Windows.Forms.CheckBox cfgTenureCheck;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

