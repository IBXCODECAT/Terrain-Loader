using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class MapManagerIO
{
    private static string savepath = Application.dataPath + "/test.ibxmap";

    private static BinaryFormatter formatter = new BinaryFormatter();

    internal static void LoadTerrainData(TerrainData tdata)
    {
        MapData mdata = null;

        using (FileStream stream = new FileStream(savepath, FileMode.Open))
        {
            mdata = (MapData)formatter.Deserialize(stream);

            Debug.Log("Deserialized Map Data");
        }

        //Set terrain sizes and resolutions
        tdata.alphamapResolution = mdata.alphamapResolution;
        tdata.heightmapResolution = mdata.heightmapResolution;
        tdata.size = new Vector3(mdata.sizeX, mdata.sizeY, mdata.sizeZ);

        //Set terrain data maps
        tdata.SetAlphamaps(0, 0, mdata.alphamapDATA);
        tdata.SetHeights(0, 0, mdata.heightmapDATA);

        //For each detail layer in our saved data, map the layer to the terrain
        for (int i = 0; i < mdata.detailLayersDATA.Length; i++)
        {
            tdata.SetDetailLayer(0, 0, i, mdata.detailLayersDATA[i]);
        }

        //Set terrain trees
        tdata.treeInstances = TreeUtility.ConvertFromSerializedTrees(mdata.serializedTrees);
    }

    internal static void SaveTerrainData(TerrainData tdata)
    {
        int alphaResolution = tdata.alphamapResolution;
        int detailmapResolution = tdata.detailResolution;

        List<int[,]> detailLayers = new List<int[,]>();

        for (int i = 0; i < tdata.detailPrototypes.Length; i++)
        {
            detailLayers.Add(tdata.GetDetailLayer(Vector2Int.zero, new Vector2Int(detailmapResolution, detailmapResolution), i));
        }

        MapData data = new MapData
        {
            alphamapResolution = alphaResolution,

            alphamapLayers = tdata.alphamapLayers,

            detailResolution = tdata.detailResolution,

            alphamapDATA = tdata.GetAlphamaps(0, 0, alphaResolution, alphaResolution),
            detailLayersDATA = detailLayers.ToArray(),
            heightmapDATA = tdata.GetHeights(0, 0, tdata.heightmapResolution, tdata.heightmapResolution),

            heightmapResolution = tdata.heightmapResolution,

            sizeX = tdata.size.x,
            sizeY = tdata.size.y,
            sizeZ = tdata.size.z,

            serializedTrees = TreeUtility.ConvertToSerializedTrees(tdata.treeInstances),
        };

        using(FileStream stream = new FileStream(savepath, FileMode.Create))
        {
            formatter.Serialize(stream, data);

            Debug.Log("Serialized Map Data");
        }
    }
}
