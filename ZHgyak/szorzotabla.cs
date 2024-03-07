namespace ZHgyak
{
    public partial class szorzotabla : Form
    {
        public szorzotabla()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int f = 0; f < 10; f++)
            {
                for (int i = 0; i < 10; i++)
                {
                    Button b = new Button();
                    b.Left = i * 40;
                    b.Top = f * 40;
                    b.Width = 40;
                    b.Height = 40;

                    b.Text = (i * f).ToString();

                    Controls.Add(b);
                }
            }
            

            
        }
    }
}