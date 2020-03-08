using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IonMobility
{
    public class MobilityCellViewModel
    {
        public MobilityCellViewModel()
        {
            Restart();
            Observable
                .Interval(TimeSpan.FromMilliseconds(50))
                .Subscribe(_ =>
                    {
                        foreach(var molecule in Molecules)
                        {
                            molecule.Move();
                        }

                        var cellGasMolecules = Molecules.OfType<NeutralMolecule>();
                        foreach (var ion in Molecules.OfType<ChargedMolecule>())
                        {
                            if (cellGasMolecules.Any(mol => mol.CollidesWith(ion)))
                            {
                                ion.Velocity = new Vector(0, ion.Velocity.Y);
                            }
                        }
                    });
        }

        public void Restart()
        {
            Molecules.Clear();
            for (var i = 0; i < 100; ++i)
                Molecules.Add(NeutralMolecule.CellGas());
            Molecules.Add(ChargedMolecule.Small());
            Molecules.Add(ChargedMolecule.Medium());
            Molecules.Add(ChargedMolecule.Large());
        }

        public ObservableCollection<Molecule> Molecules { get; } = new ObservableCollection<Molecule>();
    }
}
