using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        GetComponent<Rigidbody2D>().velocity = (transform.up * -1) * 0.5f;


        //// 時間によってYの値が0から1に変化していく。1になったら0に戻り、繰り返す。
        //float x = Mathf.Repeat(Time.time * 0.2f, 1);

        //// Yの値がずれていくオフセットを作成
        //Vector2 offset = new Vector2(x, 0);

        //// マテリアルにオフセットを設定する
        //GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
	}
}


/*
 * 
 * // 機体の移動
    public void Move (Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
 * 
 */
