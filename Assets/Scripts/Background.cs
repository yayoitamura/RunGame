using UnityEngine;

public class Background : MonoBehaviour {
    // スクロールするスピード
    private float speed = 0.3f;

    void Update () {
        switch (GameManager.instance.GAME) {
            case GameManager.GAMESTATE.BEGIN:
                scrolling ();
                break;
            case GameManager.GAMESTATE.PLAY:
                scrolling ();
                break;
            case GameManager.GAMESTATE.END:
                break;
        }
    }

    void scrolling () {
        // 時間によってxの値が0から1に変化していく。1になったら0に戻り、繰り返す。
        float x = Mathf.Repeat (Time.time * speed, 1);

        // xの値がずれていくオフセットを作成
        Vector2 offset = new Vector2 (x, 0);

        // マテリアルにオフセットを設定する
        GetComponent<Renderer> ().sharedMaterial.SetTextureOffset ("_MainTex", offset);
    }
}