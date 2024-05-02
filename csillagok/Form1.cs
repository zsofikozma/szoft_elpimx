using csillagokk.Models;

namespace csillagokk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            Pen pen = new Pen(Color.White);
            Brush brush = new SolidBrush(Color.White);

            g.FillEllipse(brush, 0, 0, 100, 100);

            hajosContext context = new hajosContext();

            var stars = from x in context.StarData
                        select new {x.Hip, x.Magnitude, x.X, x.Y };

            double nagyítás = Math.Min(ClientRectangle.Height, ClientRectangle.Width) / 2;
            int ox = ClientRectangle.Width/2, oy = ClientRectangle.Height/2;

            g.Clear(Color.DarkBlue);

            foreach ( var star in stars ) 
            {
                if (Math.Sqrt(Math.Pow(star.X, 2) + Math.Pow(star.Y, 2)) > 1) continue;
                if (star.Magnitude > 6) continue;

                double size = 20 * Math.Pow(10, star.Magnitude / -2.5);
                if (size < 1) size = 1;

                double x = star.X * nagyítás + ox;
                double y = star.Y * nagyítás + oy;

                g.FillEllipse(brush, (float)(x-size/2), (float)(y-size/2), (float)size, (float)size);
            }
            var lines = context.ConstellationLines.ToList();

            foreach ( var line in lines )
            {
                var star1 = (from x in stars
                             where x.Hip == line.Star1
                             select x).FirstOrDefault();

                var star2 = (from x in stars
                             where x.Hip == line.Star2
                             select x).FirstOrDefault();

                if(star1 == null || star2 == null) continue;

                double x1 = star1.X * nagyítás + ox;
                double y1 = star1.Y * nagyítás + oy;
                double x2 = star2.X * nagyítás + ox;
                double y2 = star2.Y * nagyítás + oy;

                g.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);

            }
        }
    }
}