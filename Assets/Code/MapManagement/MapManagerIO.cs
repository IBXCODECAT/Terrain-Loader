using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;

namespace MapManagement
{
    public static class MapManagerIO
    {
        private static string savepath = Application.streamingAssetsPath + "/ibxm/test.ibxm";

        private static BinaryFormatter formatter = new BinaryFormatter();

        private static void SetPath()
        {
            string pathExt = $"/ibxm/{SceneManager.GetActiveScene().name}.ibxm";
            savepath = Application.streamingAssetsPath + pathExt;
        }

        /// <summary>
        /// Load terrain data saved to this device
        /// </summary>
        /// <param name="tdata">The terrain data asset to apply the saved data to</param>
        internal static void LoadTerrainData(TerrainData tdata, WaterSurface wdata)
        {
            SetPath();

            MapData mdata = null;

            try
            {
                using (FileStream dataStream = new FileStream(savepath, FileMode.Open))
                {
                    using (GZipStream decompressedDataStream = new GZipStream(dataStream, CompressionMode.Decompress))
                    {
                        mdata = (MapData)formatter.Deserialize(decompressedDataStream);

                        decompressedDataStream.Close();
                        dataStream.Close();
                    }

                    Debug.Log("Deserialized Map Data");
                }
            }
            catch (IOException ex)
            {
                Debug.LogException(ex);
                mdata = null;
                return;
            }

            //Set the sea level for our water
            wdata.transform.position = new Vector3(0f, mdata.seaLevel, 0f);

            //Set terrain size so we start with the correct dimensions
            tdata.size = new Vector3(mdata.sizeX, mdata.sizeY, mdata.sizeZ);

            //Set data map resolutions so the maps we have saved will match this terrain
            tdata.alphamapResolution = mdata.alphamapsResolution;
            tdata.heightmapResolution = mdata.heightmapResolution;

            //Set the data stored in our data maps
            tdata.SetAlphamaps(0, 0, mdata.alphamapDATA);
            tdata.SetHeights(0, 0, mdata.heightmapDATA);

            //For each detail layer in our saved data, map the layer to the terrain
            for (int i = 0; i < mdata.detailmapsDATA.Length; i++)
            {
                tdata.SetDetailLayer(0, 0, i, mdata.detailmapsDATA[i]);
            }

            //Set terrain tree instances
            tdata.treeInstances = TreeUtility.ConvertFromSerializedTrees(mdata.serializedTrees);
        }

        internal static void SaveTerrainData(TerrainData tdata, WaterSurface wdata)
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
                alphamapsResolution = alphaResolution,

                alphamapLayers = tdata.alphamapLayers,

                detailmapsResolution = tdata.detailResolution,

                alphamapDATA = tdata.GetAlphamaps(0, 0, alphaResolution, alphaResolution),
                detailmapsDATA = detailLayers.ToArray(),
                heightmapDATA = tdata.GetHeights(0, 0, tdata.heightmapResolution, tdata.heightmapResolution),

                heightmapResolution = tdata.heightmapResolution,

                seaLevel = wdata.transform.position.y,

                sizeX = tdata.size.x,
                sizeY = tdata.size.y,
                sizeZ = tdata.size.z,

                serializedTrees = TreeUtility.ConvertToSerializedTrees(tdata.treeInstances),
            };

            try
            {
                SetPath();

                //Create the file and directory for the save file
                Directory.CreateDirectory(Path.GetDirectoryName(savepath));
                File.Create(savepath).Close();

                using (FileStream dataStream = new FileStream(savepath, FileMode.Create))
                {
                    using (GZipStream compressedDataStream = new GZipStream(dataStream, CompressionMode.Compress))
                    {
                        formatter.Serialize(compressedDataStream, data);

                        compressedDataStream.Close();
                        dataStream.Close();
                    }

                    Debug.Log("Serialized Map Data");
                }
            }
            catch (IOException ex)
            {
                Debug.LogException(ex);
                return;
            }

        }
    }
}