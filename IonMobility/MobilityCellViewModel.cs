using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IonMobility
{
    public class MobilityCellViewModel
    {
        public MobilityCellViewModel()
        {
            Molecules.AddRange(Enumerable.Range(1, 20).Select(_ => Molecule.CellGas()));

            Observable
                .Interval(TimeSpan.FromMilliseconds(100))
                .Subscribe(
                    _ =>
                    {
                        foreach(var molecule in Molecules)
                        {
                            molecule.Move();
                        }
                    });
        }

        public List<Molecule> Molecules { get; } = new List<Molecule>();
    }
}
