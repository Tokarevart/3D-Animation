using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _Pr.__Animation
{
    public partial class FlyingBallsF : Form
    {
        private bool TimerStarted = false, flag;
        private double nowYd = 0, nowXd = 0, nowZd = 0, prevYd;
        private double velX = 0, velY = 0, velZ = 0, dY, dX, dZ, Y0, X0, Z0;
        private int X00, Y00, Z00, x0, y0, d = 26;
        private Bitmap bmp;
        private Graphics g;
        private SolidBrush br = new SolidBrush(Color.Red);
        private SolidBrush brXYZ = new SolidBrush(Color.Blue);
        private Rectangle rec, recX, recY, recZ;
        private Timer tmr = new Timer();
        Pen myPen = new Pen(Color.Black, 5);
        Pen myPenPr = new Pen(Color.Blue, 3);

        // x0/y0 - координата начала координат осей куба по осям PictureBox-а
        // X00/Y00/Z00 - начальная координата шара в осях куба
        // X0/Y0/Z0 - координата шара в осях куба в начале движения или после удара об стенку
        // d - диаметр шара

        private void Z00n_ValueChanged(object sender, EventArgs e)
        {
            Z00 = (int)(Z00n.Value * 210);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Color.White);
            Point[] curvePoints1 = { new Point(x0, y0), new Point(x0 + 420, y0), new Point(x0 + 210, y0 + 210), new Point(x0 - 210, y0 + 210) };
            Point[] curvePoints2 = { new Point(x0, y0), new Point(x0 + 420, y0), new Point(x0 + 420, y0 - 420), new Point(x0, y0 - 420) };
            Point[] curvePoints3 = { new Point(x0, y0), new Point(x0, y0 - 420), new Point(x0 - 210, y0 - 210), new Point(x0 - 210, y0 + 210) };
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints1);
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints2);
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints3);
            g.DrawLine(myPen, x0, y0, x0 + 440, y0);
            g.DrawLine(myPen, x0, y0, x0, y0 - 440);
            g.DrawLine(myPen, x0, y0, x0 - 220, y0 + 220);
            g.DrawLine(myPenPr, x0 + X00 - Z00 / 2, y0 + Z00 / 2, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            g.DrawLine(myPenPr, x0 + X00, y0 - Y00, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            g.DrawLine(myPenPr, x0 - Z00 / 2, y0 - Y00 + Z00 / 2, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            rec = new Rectangle(x0 - d / 2 + X00 - Z00 / 2, y0 - d / 2 - Y00 + Z00 / 2, d, d);
            //recX = new Rectangle(x0 + X00 - d / 4, y0 - d / 4, d / 2, d / 2);
            //recY = new Rectangle(x0 - d / 4, y0 - Y00 - d / 4, d / 2, d / 2);
            //recZ = new Rectangle(x0 - Z00 / 2 - d / 4, y0 + Z00 / 2 - d / 4, d / 2, d / 2);
            g.FillEllipse(br, rec);
            //g.FillEllipse(brXYZ, recX);
            //g.FillEllipse(brXYZ, recY);
            //g.FillEllipse(brXYZ, recZ);
            g.DrawEllipse(Pens.Black, rec);
            //g.DrawEllipse(Pens.Black, recX);
            //g.DrawEllipse(Pens.Black, recY);
            //g.DrawEllipse(Pens.Black, recZ);
            pictureBox1.Refresh();
        }

        private void Y00n_ValueChanged(object sender, EventArgs e)
        {
            Y00 = (int)(Y00n.Value * 420);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Color.White);
            Point[] curvePoints1 = { new Point(x0, y0), new Point(x0 + 420, y0), new Point(x0 + 210, y0 + 210), new Point(x0 - 210, y0 + 210) };
            Point[] curvePoints2 = { new Point(x0, y0), new Point(x0 + 420, y0), new Point(x0 + 420, y0 - 420), new Point(x0, y0 - 420) };
            Point[] curvePoints3 = { new Point(x0, y0), new Point(x0, y0 - 420), new Point(x0 - 210, y0 - 210), new Point(x0 - 210, y0 + 210) };
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints1);
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints2);
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints3);
            g.DrawLine(myPen, x0, y0, x0 + 440, y0);
            g.DrawLine(myPen, x0, y0, x0, y0 - 440);
            g.DrawLine(myPen, x0, y0, x0 - 220, y0 + 220);
            g.DrawLine(myPenPr, x0 + X00 - Z00 / 2, y0 + Z00 / 2, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            g.DrawLine(myPenPr, x0 + X00, y0 - Y00, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            g.DrawLine(myPenPr, x0 - Z00 / 2, y0 - Y00 + Z00 / 2, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            rec = new Rectangle(x0 - d / 2 + X00 - Z00 / 2, y0 - d / 2 - Y00 + Z00 / 2, d, d);
            //recX = new Rectangle(x0 + X00 - d / 4, y0 - d / 4, d / 2, d / 2);
            //recY = new Rectangle(x0 - d / 4, y0 - Y00 - d / 4, d / 2, d / 2);
            //recZ = new Rectangle(x0 - Z00 / 2 - d / 4, y0 + Z00 / 2 - d / 4, d / 2, d / 2);
            g.FillEllipse(br, rec);
            //g.FillEllipse(brXYZ, recX);
            //g.FillEllipse(brXYZ, recY);
            //g.FillEllipse(brXYZ, recZ);
            g.DrawEllipse(Pens.Black, rec);
            //g.DrawEllipse(Pens.Black, recX);
            //g.DrawEllipse(Pens.Black, recY);
            //g.DrawEllipse(Pens.Black, recZ);
            pictureBox1.Refresh();
        }

        private void X00n_ValueChanged(object sender, EventArgs e)
        {
            X00 = (int)(X00n.Value * 420);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Color.White);
            Point[] curvePoints1 = { new Point(x0, y0), new Point(x0 + 420, y0), new Point(x0 + 210, y0 + 210), new Point(x0 - 210, y0 + 210) };
            Point[] curvePoints2 = { new Point(x0, y0), new Point(x0 + 420, y0), new Point(x0 + 420, y0 - 420), new Point(x0, y0 - 420) };
            Point[] curvePoints3 = { new Point(x0, y0), new Point(x0, y0 - 420), new Point(x0 - 210, y0 - 210), new Point(x0 - 210, y0 + 210) };
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints1);
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints2);
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints3);
            g.DrawLine(myPen, x0, y0, x0 + 440, y0);
            g.DrawLine(myPen, x0, y0, x0, y0 - 440);
            g.DrawLine(myPen, x0, y0, x0 - 220, y0 + 220);
            g.DrawLine(myPenPr, x0 + X00 - Z00 / 2, y0 + Z00 / 2, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            g.DrawLine(myPenPr, x0 + X00, y0 - Y00, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            g.DrawLine(myPenPr, x0 - Z00 / 2, y0 - Y00 + Z00 / 2, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            rec = new Rectangle(x0 - d / 2 + X00 - Z00 / 2, y0 - d / 2 - Y00 + Z00 / 2, d, d);
            //recX = new Rectangle(x0 + X00 - d / 4, y0 - d / 4, d / 2, d / 2);
            //recY = new Rectangle(x0 - d / 4, y0 - Y00 - d / 4, d / 2, d / 2);
            //recZ = new Rectangle(x0 - Z00 / 2 - d / 4, y0 + Z00 / 2 - d / 4, d / 2, d / 2);
            g.FillEllipse(br, rec);
            //g.FillEllipse(brXYZ, recX);
            //g.FillEllipse(brXYZ, recY);
            //g.FillEllipse(brXYZ, recZ);
            g.DrawEllipse(Pens.Black, rec);
            //g.DrawEllipse(Pens.Black, recX);
            //g.DrawEllipse(Pens.Black, recY);
            //g.DrawEllipse(Pens.Black, recZ);
            pictureBox1.Refresh();
        }

        public FlyingBallsF()
        {
            InitializeComponent();
            X00 = (int)(X00n.Value * 420);
            Y00 = (int)(Y00n.Value * 420);
            Z00 = (int)(Z00n.Value * 210);
            x0 = pictureBox1.Width * 2 / 5;
            y0 = pictureBox1.Height * 3 / 5 + 20;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            g.SmoothingMode = SmoothingMode.HighQuality;
            myPen.StartCap = LineCap.Round;
            myPen.EndCap = LineCap.ArrowAnchor;
            myPenPr.StartCap = LineCap.RoundAnchor;
            Point[] curvePoints1 = { new Point(x0, y0), new Point(x0 + 420, y0), new Point(x0 + 210, y0 + 210), new Point(x0 - 210, y0 + 210) };
            Point[] curvePoints2 = { new Point(x0, y0), new Point(x0 + 420, y0), new Point(x0 + 420, y0 - 420), new Point(x0, y0 - 420) };
            Point[] curvePoints3 = { new Point(x0, y0), new Point(x0, y0 - 420), new Point(x0 - 210, y0 - 210), new Point(x0 - 210, y0 + 210) };
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints1);
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints2);
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints3);
            g.DrawLine(myPen, x0, y0, x0 + 440, y0);
            g.DrawLine(myPen, x0, y0, x0 , y0 - 440);
            g.DrawLine(myPen, x0, y0, x0 - 220, y0 + 220);
            g.DrawLine(myPenPr, x0 + X00 - Z00 / 2, y0 + Z00 / 2, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            g.DrawLine(myPenPr, x0 + X00, y0 - Y00, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            g.DrawLine(myPenPr, x0 - Z00 / 2, y0 - Y00 + Z00 / 2, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            rec = new Rectangle(x0 - d / 2 + X00 - Z00 / 2, y0 - d / 2 - Y00 + Z00 / 2, d, d);
            //recX = new Rectangle(x0 + X00 - d / 4, y0 - d / 4, d / 2, d / 2);
            //recY = new Rectangle(x0 - d / 4, y0 - Y00 - d / 4, d / 2, d / 2);
            //recZ = new Rectangle(x0 - Z00 / 2 - d / 4, y0 + Z00 / 2 - d / 4, d / 2, d / 2);
            g.FillEllipse(br, rec);
            //g.FillEllipse(brXYZ, recX);
            //g.FillEllipse(brXYZ, recY);
            //g.FillEllipse(brXYZ, recZ);
            g.DrawEllipse(Pens.Black, rec);
            //g.DrawEllipse(Pens.Black, recX);
            //g.DrawEllipse(Pens.Black, recY);
            //g.DrawEllipse(Pens.Black, recZ);
        }

        private void сменитьToolStripMenuItem_Click(object sender, EventArgs e){}

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик: Токарев А.А.");
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            TimerStarted = false;
            tmr.Stop();
            X00 = (int)(X00n.Value * 420);
            Y00 = (int)(Y00n.Value * 420);
            Z00 = (int)(Z00n.Value * 210);
            g.Clear(Color.White);
            Point[] curvePoints1 = { new Point(x0, y0), new Point(x0 + 420, y0), new Point(x0 + 210, y0 + 210), new Point(x0 - 210, y0 + 210) };
            Point[] curvePoints2 = { new Point(x0, y0), new Point(x0 + 420, y0), new Point(x0 + 420, y0 - 420), new Point(x0, y0 - 420) };
            Point[] curvePoints3 = { new Point(x0, y0), new Point(x0, y0 - 420), new Point(x0 - 210, y0 - 210), new Point(x0 - 210, y0 + 210) };
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints1);
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints2);
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints3);
            g.DrawLine(myPen, x0, y0, x0 + 440, y0);
            g.DrawLine(myPen, x0, y0, x0, y0 - 440);
            g.DrawLine(myPen, x0, y0, x0 - 220, y0 + 220);
            g.DrawLine(myPenPr, x0 + X00 - Z00 / 2, y0 + Z00 / 2, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            g.DrawLine(myPenPr, x0 + X00, y0 - Y00, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            g.DrawLine(myPenPr, x0 - Z00 / 2, y0 - Y00 + Z00 / 2, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            rec = new Rectangle(x0 - d / 2 + X00 - Z00 / 2, y0 - d / 2 - Y00 + Z00 / 2, d, d);
            //recX = new Rectangle(x0 + X00 - d / 4, y0 - d / 4, d / 2, d / 2);
            //recY = new Rectangle(x0 - d / 4, y0 - Y00 - d / 4, d / 2, d / 2);
            //recZ = new Rectangle(x0 - Z00 / 2 - d / 4, y0 + Z00 / 2 - d / 4, d / 2, d / 2);
            g.FillEllipse(br, rec);
            //g.FillEllipse(brXYZ, recX);
            //g.FillEllipse(brXYZ, recY);
            //g.FillEllipse(brXYZ, recZ);
            g.DrawEllipse(Pens.Black, rec);
            //g.DrawEllipse(Pens.Black, recX);
            //g.DrawEllipse(Pens.Black, recY);
            //g.DrawEllipse(Pens.Black, recZ);
            pictureBox1.Refresh();
        }
        
        private int NowX ()
        {
            nowXd = X0 + 1.7 * dX / 200.0;
            return (int)Math.Truncate(nowXd);
        }

        private int NowZ()
        {
            nowZd = Z0 + 1.7 * dZ / 200.0;
            return (int)Math.Truncate(nowZd);
        }

        private int NowY (bool Change)
        {
            if (Change == true) prevYd = nowYd;
            nowYd = Y0 + 1.7 * dY / 8000;
            return (int)Math.Truncate(nowYd);
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (TimerStarted == true)
            {
                TimerStarted = false;
                tmr.Stop();
            }
            flag = false;
            tmr = new Timer();
            g.Clear(Color.White);
            tmr.Interval = (int)UpdFreq.Value;
            X00 = (int)(X00n.Value * 420);
            Y00 = (int)(Y00n.Value * 420);
            Z00 = (int)(Z00n.Value * 210);
            int x, y;
            int tX = 0, tY = 0, tZ = 0;
            X0 = X00;
            Y0 = Y00;
            Z0 = Z00;
            velX = (double)eX.Value * 100;
            velY = (double)eY.Value * 10000;
            velZ = (double)eZ.Value * 100;
            rec = new Rectangle(x0 - d / 2 + X00 - Z00 / 2, y0 - d / 2 - Y00 + Z00 / 2, d, d);
            //recX = new Rectangle(x0 + X00 - d / 4, y0 - d / 4, d / 2, d / 2);
            //recY = new Rectangle(x0 - d / 4, y0 - Y00 - d / 4, d / 2, d / 2);
            //recZ = new Rectangle(x0 - Z00 / 2 - d / 4, y0 + Z00 / 2 - d / 4, d / 2, d / 2);
            Point[] curvePoints1 = { new Point(x0, y0), new Point(x0 + 420, y0), new Point(x0 + 210, y0 + 210), new Point(x0 - 210, y0 + 210) };
            Point[] curvePoints2 = { new Point(x0, y0), new Point(x0 + 420, y0), new Point(x0 + 420, y0 - 420), new Point(x0, y0 - 420) };
            Point[] curvePoints3 = { new Point(x0, y0), new Point(x0, y0 - 420), new Point(x0 - 210, y0 - 210), new Point(x0 - 210, y0 + 210) };
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints1);
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints2);
            g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints3);
            g.DrawLine(myPen, x0, y0, x0 + 440, y0);
            g.DrawLine(myPen, x0, y0, x0, y0 - 440);
            g.DrawLine(myPen, x0, y0, x0 - 220, y0 + 220);
            g.DrawLine(myPenPr, x0 + X00 - Z00 / 2, y0 + Z00 / 2, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            g.DrawLine(myPenPr, x0 + X00, y0 - Y00, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            g.DrawLine(myPenPr, x0 - Z00 / 2, y0 - Y00 + Z00 / 2, x0 + X00 - Z00 / 2, y0 - Y00 + Z00 / 2);
            g.FillEllipse(br, rec);
            //g.FillEllipse(brXYZ, recX);
            //g.FillEllipse(brXYZ, recY);
            //g.FillEllipse(brXYZ, recZ);
            g.DrawEllipse(Pens.Black, rec);
            //g.DrawEllipse(Pens.Black, recX);
            //g.DrawEllipse(Pens.Black, recY);
            //g.DrawEllipse(Pens.Black, recZ);
            tmr.Tick += new EventHandler((o, ev) =>
            {
                if (NowY(false) >= 420 - d / 2 || NowY(false) <= 0)
                {
                    velY = (-1 * (velY - 9.81 * 10 * (tY - tmr.Interval))) * (double)ElastCoef.Value;
                    tY = 0;
                    if (NowY(false) >= 420 - d / 2)
                    {
                        Y0 = prevYd;
                        if (prevYd >= 420 - d / 2) flag = true;
                    }
                    else Y0 = prevYd;
                }
                if (NowX() >= 420 || NowX() <= d / 2)
                {
                    velX = -velX * (double)ElastCoef.Value;
                    tX = 0;
                    if (NowX() >= 420) X0 = 420 - d / 2;
                    else X0 = d / 2;
                }
                if (NowZ() >= 420 || NowZ() <= d / 2)
                {
                    velZ = -velZ * (double)ElastCoef.Value;
                    tZ = 0;
                    if (NowZ() >= 420) Z0 = 420 - d / 2;
                    else Z0 = d / 2;
                }
                tY += tmr.Interval;
                tX += tmr.Interval;
                tZ += tmr.Interval;
                dX = velX * tX;
                dY = -10 * (9.81 / 2) * tY * tY + velY * tY;
                dZ = velZ * tZ;
                x = NowX() - NowZ() / 2;
                y = NowY(true) - NowZ() / 2;
                if (flag == true) y = -210; // Есть проблема с коэф. упругости
                g.Clear(Color.White);
                rec = new Rectangle(x0 + x - d / 2, y0 - y - d / 2, d, d);
                //recX = new Rectangle(x0 + NowX() - d / 4, y0 - d / 4, d / 2, d / 2);
                //recY = new Rectangle(x0 - d / 4, y0 - NowY(false) - d / 4, d / 2, d / 2);
                //recZ = new Rectangle(x0 - NowZ() / 2 - d / 4, y0 + NowZ() / 2 - d / 4, d / 2, d / 2);
                g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints1);
                g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints2);
                g.FillPolygon(new SolidBrush(Color.LightGray), curvePoints3);
                g.DrawLine(myPen, x0, y0, x0 + 440, y0);
                g.DrawLine(myPen, x0, y0, x0, y0 - 440);
                g.DrawLine(myPen, x0, y0, x0 - 220, y0 + 220);
                g.DrawLine(myPenPr, x0 + NowX() - NowZ() / 2, y0 + NowZ() / 2, x0 + x, y0 - y);
                g.DrawLine(myPenPr, x0 + NowX(), y0 - NowY(false), x0 + x, y0 - y);
                g.DrawLine(myPenPr, x0 - NowZ() / 2, y0 - NowY(false) + NowZ() / 2, x0 + x, y0 - y);
                g.FillEllipse(br, rec);
                //g.FillEllipse(brXYZ, recX);
                //g.FillEllipse(brXYZ, recY);
                //g.FillEllipse(brXYZ, recZ);
                g.DrawEllipse(Pens.Black, rec);
                //g.DrawEllipse(Pens.Black, recX);
                //g.DrawEllipse(Pens.Black, recY);
                //g.DrawEllipse(Pens.Black, recZ);
                pictureBox1.Refresh();
            });
            TimerStarted = true;
            tmr.Start();
        }
    }
}
