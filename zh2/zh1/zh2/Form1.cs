using CsvHelper;
using System.ComponentModel;
using System.Globalization;
using System.IO;

namespace MintaZH2MIKU
{
    public partial class Form1 : Form
    {
        BindingList<Eredm�nyek> result = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("futoversenyzok.txt");
                var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
                var t�mb = csv.GetRecords<Eredm�nyek>();

                foreach (var item in t�mb)
                {
                    result.Add(item);
                }

                sr.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            eredm�nyekBindingSource.DataSource = result;

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                    var csv = new CsvWriter(sw, CultureInfo.InvariantCulture);
                    csv.WriteRecords(result);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (eredm�nyekBindingSource.Current == null) return;

            if (MessageBox.Show("T�rl�d-e?", "T�rl� ablakocska", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                eredm�nyekBindingSource.RemoveCurrent();
            }
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            Form2 ujform = new Form2();
            ujform.ShowDialog();
            result.Add(ujform.UjEredm�ny);
        }

        private void buttonData_Click(object sender, EventArgs e)
        {
            int usaszamolo = 0; 
            foreach (var item in result)
            {
                if(item.Nemzetiseg == "USA")
                {
                    usaszamolo ++;  
                }
            }

            int idoszamolo = 2000;
            Eredm�nyek legjobbversenyzok = new Eredm�nyek();
            foreach (var item in result)
            {
                if (item.EredmenyPerc < idoszamolo)
                {
                    idoszamolo=item.EredmenyPerc;
                    legjobbversenyzok = item;
                }
            }
            int osszido = 0;
            foreach (var item in result)
            {
                osszido += item.EredmenyPerc;
            }


            MessageBox.Show($"Itt lesznek az adatok! L�tsz�ma: {usaszamolo} Ido: {idoszamolo}" +
                $" Nev: {legjobbversenyzok.Nev} osszido:{osszido}" );
        }
    }
}