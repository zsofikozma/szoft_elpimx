namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int sor = 0; sor < 10; sor++)
            {
                for (int oszlop = 0; oszlop < 10; oszlop++)
                {
                    Button button = new Button();
                    button.Text = (sor * oszlop).ToString();
                    button.Top = sor * 40;
                    button.Left = oszlop * 41;
                    button.Height = 40;
                    button.Width = 40;
                    Controls.Add(button);
                }
            }
        }
    }
}