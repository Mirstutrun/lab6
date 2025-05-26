using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{ //Работает
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;

        GravityPoint point1;
        TeleportPoint teleport;

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter
            {
                Direction = 0,
                Spreading = 6,
                SpeedMin = 5,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 15,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter);

            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            };
            teleport = new TeleportPoint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2,
                TargetX = picDisplay.Width / 2 + 200,
                TargetY = picDisplay.Height / 2 + 100
            };

            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(teleport);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }
            picDisplay.Invalidate();
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                teleport.X = e.X;
                teleport.Y = e.Y;
            }
            else if (e.Button == MouseButtons.Right)
            {
                teleport.TargetX = e.X;
                teleport.TargetY = e.Y;
            }
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}°";
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGraviton.Value;
        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)
        {
            teleport.Radius = tbGraviton2.Value;
        }
    }
}

