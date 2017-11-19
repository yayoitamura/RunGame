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
    void Start()
    {

        // clusterPrefabsが存在しなければコルーチンを終了する
        //if (clusterPrefabs.Length == 0)
        //{
        //    yield break;
        //}

        //while (true)
        //{
        //    Debug.Log(currentclusterPrefabs);
        //    // clusterを作成する
        //    GameObject cluster = (GameObject)Instantiate(clusterPrefabs[currentclusterPrefabs], transform.position, Quaternion.identity);

        //    // cluster をEmitterの子要素にする
        //    cluster.transform.parent = transform;

        //    // clusterの子要素のEnemyが全て削除されるまで待機する
        //    while (cluster.transform.childCount != 0)
        //    {
        //        yield return new WaitForEndOfFrame();
        //    }

        //    // clusterの削除
        //    Destroy(cluster);

        //    // 格納されているclusterを全て実行したらcurrentclusterPrefabsを0にする（最初から -> ループ）
        //    if (clusterPrefabs.Length <= ++currentclusterPrefabs)
        //    {
        //        currentclusterPrefabs = 0;
        //    }

        //}
    }
  
    void Update()
    {
        switch (GameManager.instance.GAME)
        {
            case GameManager.GAMESTATE.BEGIN:
                break;
            case GameManager.GAMESTATE.PLAY:
                Appear();
                Disappear();
                Move();
                break;
            case GameManager.GAMESTATE.END:
                break;
        }


    }

    void Appear()
    {
        //int last = clusters.Count - 1;
        //Debug.Log(clusters.Count);

        if(clusters.Count == 0 || clusters[clusters.Count -1].transform.position.x < 8)
        {
            
            currentclusterPrefabs = Random.Range(0, 3);
            clusters.Add(Instantiate(clusterPrefabs[currentclusterPrefabs], transform.position, Quaternion.identity));
            //Debug.Log(clusters.Last().transform.position.x);
        }
    }

    void Disappear()
    {
        if (clusters[0].transform.position.x < -10)
        {
            Destroy(clusters[0]);
            clusters.RemoveAt(0);
        }
    }

    void Move()
    {
        for (int i = 0; i < clusters.Count; i++)
        {
            clusters[i].transform.position += transform.right * -0.05f;
        }

    }

    //void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}
}