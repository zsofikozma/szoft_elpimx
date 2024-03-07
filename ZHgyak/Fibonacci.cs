using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZHgyak
{
    public partial class Fibonacci : Form
    {
        public Fibonacci()
        {
            InitializeComponent();
        }

        private void Fibonacci_Load(object sender, EventArgs e)
        {
            int fibonacci(int n) 
            {
                if (n == 0) return 0;
                if (n == 1) return 1;
                return fibonacci(n - 1) + fibonacci(n - 2);
                
            }
        }
    }
}
