using System;

namespace SenneGameWpf.Hindernissen
{
    public class DestructableHindernis : Hindernis
    {
        private readonly Action _actionOnDestruction;

        public DestructableHindernis(double x, double y, Action actionOnDestruction)
            : base(x, y)
        {
            _actionOnDestruction = actionOnDestruction;
        }

        public DestructableHindernis(double x, double y)
            : base(x, y)
        {
        }

        public override bool IsDestructable
        {
            get { return true; }
        }

        public void Destroy()
        {
            _actionOnDestruction();
        }
    }
}