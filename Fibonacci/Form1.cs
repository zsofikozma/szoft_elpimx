Marciiii
namespace Fibonacci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Sor> sorok = new List<Sor>();

            for (int i = 0; i < 40; i++)
            {
                Sor �jSor = new Sor();
                �jSor.�rt�k = Fibonacci(i);
                �jSor.Sorsz�m = i;

                sorok.Add(�jSor);
            }

            dataGridView1.DataSource = sorok;
        }

        int Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}