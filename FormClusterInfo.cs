using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ProyectoFinal_ExpresionGenetica
{
    public partial class FormClusterInfo : Form
    {
        bool bClosed;
        public FormClusterInfo()
        {
            InitializeComponent();

            textBoxK.Text = "2";
            bClosed = false;
        }

        public bool GetClosed()
        {
            return bClosed;
        }

        public int GetK()
        {
            return int.Parse(textBoxK.Text);
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBoxK.Text, @"^[0-9]+$"))
                bClosed = true;

            Close();
        }
    }
}
