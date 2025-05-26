using System;
using System.Collections.Generic;
using System.Drawing;

namespace lab6
{
    public class TeleportPoint : IImpactPoint
    {
        public int Radius = 30;
        public float TargetX;
        public float TargetY;

        public override void ImpactParticle(Particle particle)
        {
            float dx = particle.X - X;
            float dy = particle.Y - Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance < Radius)
            {
                particle.X = TargetX;
                particle.Y = TargetY;
            }
        }

        public override void Render(Graphics g)
        {
            using (var pen = new Pen(Color.Blue, 2))
            using (var brush = new SolidBrush(Color.Blue))
            {
                g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);
                g.FillEllipse(brush, TargetX - 5, TargetY - 5, 10, 10);

                g.DrawLine(pen, X, Y, TargetX, TargetY);
            }
        }
    }
}
