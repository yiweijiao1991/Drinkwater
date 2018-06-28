using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeWater
{
    public partial class Form2 : Form
    {
        System.Windows.Forms.Timer timeform1;
        public Form2( ref System.Windows.Forms.Timer time1)
        {
            InitializeComponent();
            timeform1 = time1;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            timeform1.Start();
        }
    }
}
