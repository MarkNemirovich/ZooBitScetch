using System;
using System.Collections.Generic;

namespace ZooBitSketch
{
    internal abstract class Workshop
    {
        public readonly string Name;
        public Active enhancingActive { get; protected set; }
        public List<Active> enhancingMaterials { get; protected set; }
        public void ChooseActive(Active baseActive)
        {
            enhancingActive = baseActive;
        }
        protected virtual void UpgradeActive()
        {
            enhancingActive.Evolve();
            foreach(var Active in enhancingMaterials)
                Active.Sacrifice();
        }
        protected virtual void AddAsSource(Active material)
        {
            enhancingMaterials.Add(material);
        }
    }
}
