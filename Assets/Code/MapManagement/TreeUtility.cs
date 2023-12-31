using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapManagement
{
    public static class TreeUtility
    {
        internal static SerializedTree[] ConvertToSerializedTrees(TreeInstance[] trees)
        {
            List<SerializedTree> treeList = new List<SerializedTree>();

            foreach (TreeInstance tree in trees)
            {
                SerializedTree t = new SerializedTree
                {
                    lightmapA = tree.lightmapColor.a,
                    lightmapB = tree.lightmapColor.b,
                    lightmapG = tree.lightmapColor.g,
                    lightmapR = tree.lightmapColor.r,

                    posX = tree.position.x,
                    posY = tree.position.y,
                    posZ = tree.position.z,

                    prototypeIndex = tree.prototypeIndex,

                    rotationXZ = tree.rotation,

                    scaleXZ = tree.widthScale,
                    scaleY = tree.heightScale,

                    tintB = tree.color.b,
                    tintG = tree.color.g,
                    tintR = tree.color.r
                };

                treeList.Add(t);
            }

            return treeList.ToArray();
        }

        internal static TreeInstance[] ConvertFromSerializedTrees(SerializedTree[] trees)
        {
            List<TreeInstance> treesList = new List<TreeInstance>();

            foreach (SerializedTree tree in trees)
            {
                TreeInstance i = new TreeInstance
                {
                    lightmapColor = new Color(tree.lightmapR, tree.lightmapG, tree.lightmapB, tree.lightmapA),
                    color = new Color(tree.tintR, tree.tintG, tree.tintB),
                    heightScale = tree.scaleY,
                    position = new Vector3(tree.posX, tree.posY, tree.posZ),
                    prototypeIndex = tree.prototypeIndex,
                    rotation = tree.rotationXZ,
                    widthScale = tree.scaleXZ
                };

                treesList.Add(i);
            }


            return treesList.ToArray();
        }
    }
}