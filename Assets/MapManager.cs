using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class MapManager
{
    private static string savepath = Application.dataPath + "/test.ibxmap";

    private static BinaryFormatter formatter= new BinaryFormatter();

    public static MapData LoadMap()
    {
        using(FileStream stream = new FileStream(savepath, FileMode.Open))
        {
            MapData mdata = (MapData)formatter.Deserialize(stream);

            Debug.Log("Deserialized Map Data");

            return mdata;
        }
    }

    public static void SaveMap(MapData map)
    {
        using(FileStream stream = new FileStream(savepath, FileMode.Create))
        {
            formatter.Serialize(stream, map);

            Debug.Log("Serialized Map Data");
        }
    }
}
