using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Projekt2
{
    public partial class Form1 : Form
    {
        PictureBox jatekos;
        List<PictureBox> bricks = new List<PictureBox>();
        Label elapsedTimeLabel = new Label();
        int elapsedTimeInSeconds = 0;
        Label stepsLabel = new Label();
        int steps = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("TextFile1.txt");
            int s = 0;
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                for (int o = 0; o < sor.Length; o++)
                {
                    if (sor[o] == '#')
                    {
                        PictureBox pb = new();
                        pb.Top = s * 20;
                        pb.Left = o * 20;
                        pb.Width = 20;
                        pb.Height = 20;
                        pb.BackColor = Color.Fuchsia;

                        Controls.Add(pb);
                        bricks.Add(pb);
                    }
                }
                s++;
            }
            sr.Close();

            jatekos = new();
            jatekos.Height = 20;
            jatekos.Width = 20;
            jatekos.BackColor = Color.Red;
            jatekos.Top = 0;
            jatekos.Left = 0;

            Controls.Add(jatekos);

            elapsedTimeLabel.AutoSize = true;
            elapsedTimeLabel.Top = 10;
            elapsedTimeLabel.Left = 1300;
            elapsedTimeLabel.Font = new Font("Arial", 14);
            Controls.Add(elapsedTimeLabel);

            stepsLabel.AutoSize = true;
            stepsLabel.Top = 40;
            stepsLabel.Left = 1300;
            stepsLabel.Font = new Font("Arial", 14);
            Controls.Add(stepsLabel);

            this.KeyDown += Form1_KeyDown;

            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;

            MessageBox.Show("Nyomd meg az OK gombot a játék indításához!");
            elapsedTimeInSeconds = 0;
            timer1.Start();
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            int x = jatekos.Location.X;
            int y = jatekos.Location.Y;

            if (e.KeyCode == Keys.Left)
            {
                x -= 20;
                steps++;
            }

            if (e.KeyCode == Keys.Right)
            {
                x += 20;
                steps++;
            }

            if (e.KeyCode == Keys.Up)
            {
                y -= 20;
                steps++;
            }

            if (e.KeyCode == Keys.Down)
            {
                y += 20;
                steps++;
            }

            var brick = (from s in bricks
                         where s.Left == x && s.Top == y
                         select s).FirstOrDefault();

            if (brick == null)
            {
                jatekos.Left = x;
                jatekos.Top = y;
            }

            if (jatekos.Location.X == 20 * 60 && jatekos.Location.Y == 20 * 40)
            {
                timer1.Stop();

                MessageBox.Show($"Gratulálok! Teljesítetted a játékot!\n\nIdõ: {elapsedTimeInSeconds} másodperc\nLépések száma: {steps}", "Játék vége");

                DialogResult result = MessageBox.Show("Szeretnél újra játszani?", "Játék vége", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    RestartGame();
                }
                else
                {
                    this.Close();
                }

                return;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsedTimeInSeconds++;
            elapsedTimeLabel.Text = $"Eltelt idõ: {elapsedTimeInSeconds} másodperc";
            stepsLabel.Text = $"Lépések száma: {steps}";
        }

        private void RestartGame()
        {

            LoadBricks();

            jatekos.Left = 0;
            jatekos.Top = 0;

            elapsedTimeInSeconds = 0;
            steps = 0;

            elapsedTimeLabel.Text = $"Eltelt idõ: {elapsedTimeInSeconds} másodperc";
            stepsLabel.Text = $"Lépések száma: {steps}";

            timer1.Start();
        }

        private void LoadBricks()
        {

            foreach (PictureBox brick in bricks)
            {
                Controls.Remove(brick);
            }
            bricks.Clear();

            StreamReader sr = new StreamReader("TextFile1.txt");
            int s = 0;
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                for (int o = 0; o < sor.Length; o++)
                {
                    if (sor[o] == '#')
                    {
                        PictureBox pb = new();
                        pb.Top = s * 20;
                        pb.Left = o * 20;
                        pb.Width = 20;
                        pb.Height = 20;
                        pb.BackColor = Color.Fuchsia;

                        Controls.Add(pb);
                        bricks.Add(pb);
                    }
                }
                s++;
            }
            sr.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}