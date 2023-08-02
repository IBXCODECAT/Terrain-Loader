using System;

namespace MapManagement
{
    [Serializable]
    public struct SerializedTree
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
        public float seaLevel;

        public int alphamapHeight;
        public int alphamapLayers;

        public int alphamapsResolution;
        public int detailmapsResolution;
        public int heightmapResolution;

        public float[,,] alphamapDATA;
        public int[][,] detailmapsDATA;
        public float[,] heightmapDATA;

        public float sizeX;
        public float sizeY;
        public float sizeZ;

        public SerializedTree[] serializedTrees;
    }
}