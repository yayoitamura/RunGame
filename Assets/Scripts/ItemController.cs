using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour
{
    // clustersプレハブを格納する
    public GameObject[] clusters;

    // 現在のclusters
    private int currentclusters;

    IEnumerator Start()
    {

        // clustersが存在しなければコルーチンを終了する
        if (clusters.Length == 0)
        {
            yield break;
        }

        while (true)
        {
            // clusterを作成する
            GameObject cluster = (GameObject)Instantiate(clusters[currentclusters], transform.position, Quaternion.identity);

            // cluster をEmitterの子要素にする
            cluster.transform.parent = transform;

            // clusterの子要素のEnemyが全て削除されるまで待機する
            while (cluster.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            // clusterの削除
            Destroy(cluster);

            // 格納されているclusterを全て実行したらcurrentclustersを0にする（最初から -> ループ）
            if (clusters.Length <= ++currentclusters)
            {
                currentclusters = 0;
            }

        }
    }
  
    void Update()
    {
        switch (GameManager.instance.GAME)
        {
            case GameManager.GAMESTATE.BEGIN:
                break;
            case GameManager.GAMESTATE.PLAY:
                Move();
                break;
            case GameManager.GAMESTATE.END:
                break;
        }


    }

    void Move()
    {
        transform.position += transform.right * -0.05f;
    }
}