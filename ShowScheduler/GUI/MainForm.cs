﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowScheduler
{
    public partial class MainForm : Form
    {
        Scheduler scheduler = new Scheduler();

        public MainForm()
        {
            InitializeComponent();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void GetShowsBtn_Click(object sender, EventArgs e)
        {
            showList.DataSource = scheduler.FetchShows();
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            scheduler.Generate(cfgTenureCheck.Checked);
        }
    }
}
