using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ManagingAdmissionContest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
           SaveFileDialog saveFile = new SaveFileDialog();
           saveFile.ShowDialog();
           saveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
     }
    }
}
