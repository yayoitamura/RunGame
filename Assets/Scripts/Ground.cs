using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    // groundsプレハブを格納する
    public GameObject[] grounds;
    private GameObject ground;
    private float speed = 0.2f;
    Collider stepCollider;

    // 現在のground
    private int currentGround;

    IEnumerator Start()
    {
        // Waveが存在しなければコルーチンを終了する
        if (grounds.Length == 0)
        {
            yield break;
        }

        while (true)
        {

            // groundを作成する
            ground = (GameObject)Instantiate(grounds[currentGround], transform.position, Quaternion.identity);

            // groundをGroundの子要素にする
            ground.transform.parent = transform;

            // groundの子要素のstepが全て削除されるまで待機する
            while (ground.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            // groundの削除
            Destroy(ground);

            // 格納されているWaveを全て実行したらcurrentgroundを0にする（最初から -> ループ）
            if (grounds.Length <= ++currentGround)
            {
                currentGround = 0;
            }

        }

        //stepCollider = this.gameObject.GetComponentInChildren<BoxCollider>();
        //Debug.Log(this.gameObject.GetComponentInChildren<BoxCollider>);
    }

    private void Update()
    {
        Debug.Log(stepCollider);
        transform.position += transform.right * -0.05f;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("contact");
        if (collision.gameObject.tag == "contact")
        {
            ground = (GameObject)Instantiate(grounds[currentGround], transform.position, Quaternion.identity);

            // groundをGroundの子要素にする
            ground.transform.parent = transform;
        }
    }
}

/*
 * private GameObject child = transform.FindChild ("Child").gameObject;
 * Collider stepCollider = this.gameObject.GetComponentInChildren<BoxCollider>();
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
