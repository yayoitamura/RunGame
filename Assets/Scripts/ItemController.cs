using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemController : MonoBehaviour
{
    // clusterPrefabsプレハブを格納する
    public GameObject[] clusterPrefabs;

    // 現在のclusterPrefabs
    private int currentclusterPrefabs;
    private List<GameObject> clusters = new List<GameObject>();
  
    void Update()
    {
        switch (GameManager.instance.GAME)
        {
            case GameManager.GAMESTATE.BEGIN:
                break;
            case GameManager.GAMESTATE.PLAY:
                Appear();
                Vanish();
                Move();
                break;
            case GameManager.GAMESTATE.END:
                break;
        }


    }

    void Appear()
    {
        if(clusters.Count == 0 || clusters[clusters.Count -1].transform.position.x < 8)
        {
            currentclusterPrefabs = Random.Range(0, 3);
            clusters.Add(Instantiate(clusterPrefabs[currentclusterPrefabs], transform.position, Quaternion.identity));
        }
    }

    void Move()
    {
        for (int i = 0; i < clusters.Count; i++)
        {
            clusters[i].transform.position += transform.right * -0.05f;
        }
    }

    void Vanish()
    {
        if (clusters[0].transform.position.x < -10)
        {
            Destroy(clusters[0]);
            clusters.RemoveAt(0);
        }
    }
}