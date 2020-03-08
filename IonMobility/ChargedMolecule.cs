using System.Windows.Media;
using System.Windows;
using System;

namespace IonMobility
{
    public class ChargedMolecule : Molecule
    {
        private ChargedMolecule(Color color, double diameter, double verticalPosition) : base(color, diameter)
        {
            Position = new Point(0, verticalPosition);
            Velocity = new Vector(0.002, 0.0);
        }

        public static Molecule Small()
        {
            return new ChargedMolecule(Colors.Firebrick, 10, 0.1);
        }

        public static Molecule Medium()
        {
            return new ChargedMolecule(Colors.RoyalBlue, 50, 0.4);
        }

        public static Molecule Large()
        {
            return new ChargedMolecule(Colors.Gold, 100, 0.75);
        }

        public override void Move()
        {
            Accelerate();
            base.Move();
            Constrain();
        }

        private void Constrain()
        {
            if (Position.X > 1.0)
            {
                Position = new Point(1.0, Position.Y);
                Velocity = new Vector();
            }
        }

        private void Accelerate()
        {
            Velocity = new Vector(Velocity.X + 0.001, Velocity.Y);
        }
    }
}