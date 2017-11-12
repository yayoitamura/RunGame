﻿using UnityEngine;

public class Background : MonoBehaviour
{
    // スクロールするスピード
    private float speed = 0.2f;

    enum GAME
    {
        BEGIN,
        PLAY,
        END,
    };
    private GAME game = GAME.BEGIN;

    void Update()
    {
        // 時間によってYの値が0から1に変化していく。1になったら0に戻り、繰り返す。
        float x = Mathf.Repeat(Time.time * speed, 1);

         // Yの値がずれていくオフセットを作成
         Vector2 offset = new Vector2(x, 0);

         // マテリアルにオフセットを設定する
         GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    public void StartGame()
    {
        game = GAME.PLAY;
    }
}



/*
 * 
 * 
 * using UnityEngine;

public class Background : MonoBehaviour
{
    // スクロールするスピード
    private float speed = 0.2f;
    private string state = "none";

    void Update()
    {
        if (state == "start")
        {
            // 時間によってYの値が0から1に変化していく。1になったら0に戻り、繰り返す。
            float x = Mathf.Repeat(Time.time * speed, 1);

            // Yの値がずれていくオフセットを作成
            Vector2 offset = new Vector2(x, 0);

            // マテリアルにオフセットを設定する
            GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
        }
    }

    public void StartGame()
    {
        state = "start";
    }
}



*/