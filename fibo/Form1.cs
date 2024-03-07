namespace fibo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Button b = new Button();
                b.Top = i * 30;
                b.Text = fibonacci(i).ToString();
                Controls.Add(b);
            }

            int fibonacci(int i)
            {
                if (i == 0) return 0;
                if (i == 1) return 1;
                return fibonacci(i - 1) + fibonacci(i - 2);

            }
        }
    }
}