using System.Windows.Media;
using System.Windows;

namespace IonMobility
{
    public class NeutralMolecule : Molecule
    {
        private NeutralMolecule(double diameter) : base(Colors.CadetBlue, diameter) { }

        public override void Move()
        {
            base.Move();
            Constrain();
        }

        private void Constrain()
        {
            var newPosition = Position;

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
            return new NeutralMolecule(10);
        }
    }
}