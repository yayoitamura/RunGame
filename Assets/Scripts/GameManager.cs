using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public enum GAMESTATE {
        BEGIN,
        PLAY,
        END,
        };
        public GAMESTATE GAME = GAMESTATE.BEGIN;
        private static GameManager _instance;

        public static GameManager instance {
        get {
        if (!_instance) {
        var go = new GameObject ("GameManager");
        DontDestroyOnLoad (go);
        _instance = go.AddComponent<GameManager> ();
            }
            return _instance;
        }
    }

    private void Awake () {
        if (_instance == null) {
            _instance = this;
        } else {
            // 本来のSingletonの実装ではコンストラクタをprivateにして外からnewできないようにするが、
            // MonoBehaviourではコンストラクタを定義できない。
            // そのため、すでにインスタンスがあったら破棄する。
            Destroy (this);
        }
    }

    void Update () {
        switch (GameManager.instance.GAME) {
            case GameManager.GAMESTATE.BEGIN:
                break;
            case GameManager.GAMESTATE.PLAY:
                break;
            case GameManager.GAMESTATE.END:
                SceneLoard ();
                break;
        }
    }

    void SceneLoard () {
        var phase = GodTouch.GetPhase ();
        if (phase == GodPhase.Began) {
            SceneManager.LoadScene (0);
        }
    }
}