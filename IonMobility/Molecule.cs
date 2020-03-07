using System.Windows.Media;
using System.Windows;
using System;
using ReactiveUI;

namespace IonMobility
{
    public class Molecule : ReactiveObject
    {
        private static readonly Random random = new Random(DateTime.Now.Second);

        private Molecule(Color color, double diameter)
        {
            Color = color;
            Diameter = diameter;

            var angle = random.NextDouble() * 360.0;
            Velocity = new Vector(0.02 * Math.Cos(angle), 0.02 * Math.Sin(angle));
//            Velocity = new Vector(random.NextDouble() / 50.0, random.NextDouble() / 50.0);
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

        public void Move()
        {
            var newPosition = new Point(Position.X + Velocity.X, Position.Y + Velocity.Y);

            if (newPosition.X < 0.0)
            {
                newPosition.X = -newPosition.X;
                Velocity = new Vector(-Velocity.X, Velocity.Y);
            }
            else if (newPosition.X > 1.0)
            {
                newPosition.X = 2.0 - newPosition.X;
                Velocity = new Vector(-Velocity.X, Velocity.Y);
            }

            if (newPosition.Y < 0.0)
            {
                newPosition.Y = -newPosition.Y;
                Velocity = new Vector(Velocity.X, -Velocity.Y);
            }
            else if (newPosition.Y > 1.0)
            {
                newPosition.Y = 2.0 - newPosition.Y;
                Velocity = new Vector(Velocity.X, -Velocity.Y);
            }

            Position = newPosition;
        }

        public static Molecule CellGas()
        {
            return new Molecule(Colors.CadetBlue, 10);
        }

        public static Molecule Small()
        {
            return new Molecule(Colors.Firebrick, 10);
        }

        public static Molecule Medium()
        {
            return new Molecule(Colors.RoyalBlue, 50);
        }

        public static Molecule Large()
        {
            return new Molecule(Colors.Gold, 100);
        }
    }
}