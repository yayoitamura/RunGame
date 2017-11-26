using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

    private Vector3 topPosition = new Vector3 (11, 3, 0);
    private Vector3 middlePosition = new Vector3 (11, -1, 0);
    // ItemPatternPrefabsプレハブを格納する
    public GameObject[] ItemPatternPrefabs;
    private List<GameObject> itemPatterns = new List<GameObject> ();

    void Update () {
        switch (GameManager.instance.GAME) {
            case GameManager.GAMESTATE.BEGIN:
                break;
            case GameManager.GAMESTATE.PLAY:
                Appear ();
                Move ();
                Vanish ();
                break;
            case GameManager.GAMESTATE.END:
                Reset ();
                break;
        }
    }

    private void Reset () {
        if (itemPatterns.Count != 0) {
            for (int i = 0; i < itemPatterns.Count; i++) {
                Destroy (itemPatterns[i]);
            }
        }
        itemPatterns.Clear ();
    }

    void Appear () {
        if (itemPatterns.Count == 0 || itemPatterns[itemPatterns.Count - 1].transform.position.x < 8) {
            int middlePrefab = Random.Range (0, ItemPatternPrefabs.Length);
            itemPatterns.Add (Instantiate (ItemPatternPrefabs[middlePrefab], middlePosition, Quaternion.identity));
            int topPrefab = Random.Range (0, ItemPatternPrefabs.Length);
            itemPatterns.Add (Instantiate (ItemPatternPrefabs[topPrefab], topPosition, Quaternion.identity));
        }
    }

    void Move () {
        for (int i = 0; i < itemPatterns.Count; i++) {
            itemPatterns[i].transform.position += transform.right * -0.05f;
        }
    }

    void Vanish () {
        if (itemPatterns[0].transform.position.x < -10) {
            Destroy (itemPatterns[0]);
            itemPatterns.RemoveAt (0);
        }
    }
}