using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] TerrainData tdata;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            TestSave();
        }

        if(Input.GetKeyDown(KeyCode.F2))
        {
            TestLoad();
        }
    }

    private void TestSave()
    {
        Debug.Log(tdata.heightmapResolution);

        float y = tdata.alphamapHeight;

        int alphaResolution = tdata.alphamapResolution;

        MapData mdata = new MapData
        {
            alphamapResolution = alphaResolution,
            alphamapDATA = tdata.GetAlphamaps(0, 0, alphaResolution, alphaResolution),

            alphamapLayers = tdata.alphamapLayers,

            detailResolution = tdata.detailResolution,

            heightmapDATA = tdata.GetHeights(0, 0, tdata.heightmapResolution, tdata.heightmapResolution),
            heightmapResolution = tdata.heightmapResolution,

            mapSizeX = tdata.size.x,
            mapSizeY = tdata.size.y,
            mapSizeZ = tdata.size.z,

            //trees = tdata.treeInstances
        };

        Debug.Log(tdata.size.x);
        Debug.Log(tdata.size.y);

        MapManager.SaveMap(mdata);
    }

    private void TestLoad()
    {
        MapData mdata = MapManager.LoadMap();

        tdata.SetHeights(0, 0, mdata.heightmapDATA);
        tdata.size = new Vector3(mdata.mapSizeX, mdata.mapSizeY, mdata.mapSizeZ);
    }
}
