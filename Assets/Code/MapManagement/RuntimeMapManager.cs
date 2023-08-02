using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace MapManagement
{
    public class RuntimeMapManager : MonoBehaviour
    {
        [SerializeField] TerrainData tdata;
        [SerializeField] WaterSurface wdata;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                TestSave();
            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                TestLoad();
            }
        }

        private void TestSave()
        {
            MapManagerIO.SaveTerrainData(tdata, wdata);
        }

        private void TestLoad()
        {
            MapManagerIO.LoadTerrainData(tdata, wdata);
        }
    }
}