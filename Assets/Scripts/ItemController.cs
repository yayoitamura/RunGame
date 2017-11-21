﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemController : MonoBehaviour
{
    // ItemPatternPrefabsプレハブを格納する
    public GameObject[] ItemPatternPrefabs;
    private List<GameObject> itemPatterns = new List<GameObject>();
  
    void Update()
    {
        switch (GameManager.instance.GAME)
        {
            case GameManager.GAMESTATE.BEGIN:
                Reset();
                break;
            case GameManager.GAMESTATE.PLAY:
                Appear();
                Move();
                Vanish();
                break;
            case GameManager.GAMESTATE.END:
                break;
        }
    }

    private void Reset()
    {
        if (itemPatterns.Count != 0)
        {
            for (int i = 0; i < itemPatterns.Count; i++)
            {
                Destroy(itemPatterns[i]);
            }
        }
        itemPatterns.Clear();
    }

    void Appear()
    {
        if(itemPatterns.Count == 0 || itemPatterns[itemPatterns.Count -1].transform.position.x < 8)
        {
            int currentPrefab = Random.Range(0, ItemPatternPrefabs.Length);
            itemPatterns.Add(Instantiate(ItemPatternPrefabs[currentPrefab], transform.position, Quaternion.identity));
        }
    }

    void Move()
    {
        for (int i = 0; i < itemPatterns.Count; i++)
        {
            itemPatterns[i].transform.position += transform.right * -0.05f;
        }
    }

    void Vanish()
    {
        if (itemPatterns[0].transform.position.x < -10)
        {
            Destroy(itemPatterns[0]);
            itemPatterns.RemoveAt(0);
        }
    }
}