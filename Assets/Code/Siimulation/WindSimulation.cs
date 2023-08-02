using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simulation
{
    public class WindSimulation : MonoBehaviour
    {
        [SerializeField] protected bool simulate = true;
        [SerializeField] protected float simulationSpeed = 1;

        [SerializeField] protected float simulationDelayMin = 10;
        [SerializeField] protected float simulationDelayMax = 40;

        [SerializeField] protected WindZone windInfo;

        float simulationTimer = 0;
        Quaternion rotationObjective = Quaternion.identity;

        internal virtual void SimulationStep()
        {
            simulationTimer = 0;
            rotationObjective = Quaternion.Euler(0, Random.Range(-180, 180), 0);

            Debug.Log(rotationObjective.eulerAngles.y);
        }

        private IEnumerator Start()
        {
            while(true)
            {
                if(simulate) SimulationStep();

                float delay = Random.Range(simulationDelayMin, simulationDelayMax) * simulationSpeed;
                yield return new WaitForSeconds(delay);
            }
        }

        private void Update()
        {
            simulationTimer += Time.deltaTime;

            windInfo.transform.eulerAngles = new Vector3(0f, rotationObjective.eulerAngles.y, 0f);

            //windInfo.transform.rotation = Quaternion.Slerp(transform.rotation, rotationObjective, 1);
        }
    }
}
