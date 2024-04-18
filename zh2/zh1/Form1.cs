using CsvHelper;
using System.ComponentModel;
using System.Globalization;

namespace MintaZH
{
    public partial class Form1 : Form
    {
        BindingList<Vizsgak�rd�s> k�rd�sek = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("hajozasi_szabalyzat_coma.txt");
                var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
                var tomb = csv.GetRecords<Vizsgak�rd�s>();

                foreach (var item in tomb)
                {
                    k�rd�sek.Add(item);
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
            vizsgak�rd�sBindingSource.DataSource = k�rd�sek;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();

                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(save.FileName);
                    var csv = new CsvWriter(sw, CultureInfo.InvariantCulture);
                    csv.WriteRecords(k�rd�sek);
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
            if (vizsgak�rd�sBindingSource.Current == null) return;

            if (MessageBox.Show("Szeretn�d t�r�lni?", "T�rl� ablakocska", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                vizsgak�rd�sBindingSource.RemoveCurrent();
            }
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            FormAddNew formAddNew = new FormAddNew();

            if (formAddNew.ShowDialog() == DialogResult.OK)
            {
                k�rd�sek.Add(formAddNew.�jVizsgak�rd�s);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (vizsgak�rd�sBindingSource.Current == null) return;

            FormEdit formEdit = new FormEdit();
            formEdit.�jVizsgak�rd�s = vizsgak�rd�sBindingSource.Current as Vizsgak�rd�s;
            formEdit.Show();

        }
    }
}