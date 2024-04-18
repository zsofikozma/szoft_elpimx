using CsvHelper;
using System.ComponentModel;
using System.Globalization;

namespace MintaZH
{
    public partial class Form1 : Form
    {
        BindingList<Vizsgakérdés> kérdések = new();

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
                var tomb = csv.GetRecords<Vizsgakérdés>();

                foreach (var item in tomb)
                {
                    kérdések.Add(item);
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
            vizsgakérdésBindingSource.DataSource = kérdések;
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
                    csv.WriteRecords(kérdések);
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
            if (vizsgakérdésBindingSource.Current == null) return;

            if (MessageBox.Show("Szeretnéd törölni?", "Törlõ ablakocska", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                vizsgakérdésBindingSource.RemoveCurrent();
            }
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            FormAddNew formAddNew = new FormAddNew();

            if (formAddNew.ShowDialog() == DialogResult.OK)
            {
                kérdések.Add(formAddNew.ÚjVizsgakérdés);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (vizsgakérdésBindingSource.Current == null) return;

            FormEdit formEdit = new FormEdit();
            formEdit.ÚjVizsgakérdés = vizsgakérdésBindingSource.Current as Vizsgakérdés;
            formEdit.Show();

        }
    }
}