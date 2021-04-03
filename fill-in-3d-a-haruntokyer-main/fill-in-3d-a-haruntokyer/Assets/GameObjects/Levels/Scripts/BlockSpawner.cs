﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    Vector3 blockPos = Vector3.zero;

    public int blockCount = 0;

    public List<GameObject> CreateBlockFromImage(LevelInfo levelInfo, Transform transform)
    {
        List<GameObject> createdCubes = new List<GameObject>();
        

        for (int x = 0; x < levelInfo.sprite.texture.width; x++)
        {
            for (int y = 0; y < levelInfo.sprite.texture.height; y++)
            {
                Color color = levelInfo.sprite.texture.GetPixel(x, y);

                if (color.a == 0)
                {
                    continue;
                }

                blockPos = new Vector3(
                    levelInfo.size * (x - (levelInfo.sprite.texture.width * .5f)),
                    levelInfo.size * .5f,
                    levelInfo.size * (y - (levelInfo.sprite.texture.height * .5f)));

                GameObject cubeObj = Instantiate(levelInfo.baseObj, transform);
                cubeObj.transform.localPosition = blockPos;

                cubeObj.GetComponent<Renderer>().material.color = color;
                cubeObj.GetComponent<MeshRenderer>().enabled = false;
                cubeObj.transform.localScale = Vector3.one * levelInfo.size;

                createdCubes.Add(cubeObj);

               
            }
        }
        blockCount = createdCubes.Count;
        Debug.Log("blok sayısı:"+blockCount);
        return createdCubes;
    }
    
}