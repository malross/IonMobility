using System.Windows.Media;
using System.Windows;
using System;
using ReactiveUI;

namespace IonMobility
{
    public class Molecule : ReactiveObject
    {
        private static readonly Random random = new Random(DateTime.Now.Second);

        protected Molecule(Color color, double diameter)
        {
            Color = color;
            Diameter = diameter;

            var angle = random.NextDouble() * 360.0;
            Velocity = new Vector(0.02 * Math.Cos(angle), 0.02 * Math.Sin(angle));
            Position = new Point(random.NextDouble(), random.NextDouble());
        }

        public Color Color { get; }
        public double Diameter { get; }
        public Vector Velocity { get; set; }

        private Point position;
        public Point Position
        {
            get => position;
            set => this.RaiseAndSetIfChanged(ref position, value);
        }

        public virtual void Move()
        {
            Position = new Point(Position.X + Velocity.X, Position.Y + Velocity.Y);
        }

        public bool CollidesWith(Molecule other)
        {
            var touchingDistance = (this.Diameter + other.Diameter) / 2000;
            return (Math.Abs(this.Position.X - other.Position.X) < touchingDistance)
                && (Math.Abs(this.Position.Y - other.Position.Y) < touchingDistance);
        }
    }
}