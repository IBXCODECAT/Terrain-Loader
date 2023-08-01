using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public struct Tree
{
    public int tintR;
    public int tintG;
    public int tintB;

    public float scaleXZ;
    public float scaleY;

    public int lightmapR;
    public int lightmapG;
    public int lightmapB;
    public int lightmapA;

    public float posX;
    public float posY;
    public float posZ;

    public int prototypeIndex;

    public float rotationXZ;


}

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

    public Tree[] trees;
}
