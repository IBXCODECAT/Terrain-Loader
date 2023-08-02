using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace Simulation
{
    public class WaterSimulation : WindSimulation
    {
        [SerializeField] private WaterSurface wdata;

        internal override void SimulationStep()
        {
            base.SimulationStep();
        }
    }
}
