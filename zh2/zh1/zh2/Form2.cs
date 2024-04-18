using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MintaZH2MIKU
{
    public partial class Form2 : Form
    {
        public Eredmények UjEredmény { get; set; }

        public Form2()
        {
            InitializeComponent();
            UjEredmény = new Eredmények();
            bindingSource1.DataSource = UjEredmény;
        }
    }
}
