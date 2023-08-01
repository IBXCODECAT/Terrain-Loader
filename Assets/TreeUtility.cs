using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TreeUtility
{
    internal static Tree[] ConvertToTrees(TreeInstance[] trees)
    {
        List<Tree> treeList = new List<Tree>();

        foreach(TreeInstance tree in trees)
        {
            Tree t = new Tree
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

    internal static TreeInstance[] ConvertToTreeInstances(Tree[] trees)
    {
        List<TreeInstance> treesList = new List<TreeInstance>();

        foreach (Tree tree in trees)
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
