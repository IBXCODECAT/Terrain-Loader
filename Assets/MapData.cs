using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MapData
{
    public int alphamapHeight;
    public int alphamapResolution;
    public float[,,] alphamapDATA;
    public int alphamapLayers;

    public int detailResolution;

    public int heightmapResolution;
    public float[,] heightmapDATA;

    public float mapSizeX;
    public float mapSizeY;
    public float mapSizeZ;

    //public TreeInstance[] trees;
}
