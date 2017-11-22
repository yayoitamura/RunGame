using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public GameObject infinity;
    // groundsプレハブを格納する
    private List<GameObject> grounds = new List<GameObject>();
    public GameObject ground;

    private void Start()
    {
        Vector3 placePosition = new Vector2(-6.5f, -4.5f);
        for (int i = 0; i < 5; i++)
        {
            grounds.Add(Instantiate(ground, placePosition, Quaternion.identity));
            placePosition.x += 4.7f;
            Debug.Log(ground.transform.localScale.x);
        }

    }

    private void Update()
    {
        switch (GameManager.instance.GAME)
        {
            case GameManager.GAMESTATE.BEGIN:
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

    void Appear()
    {
        //if (grounds.Count == 0 || grounds[grounds.Count - 1].transform.position.x < 8)
        //{
        //    //placePosition.x += 4.7f;
        //    //int currentPrefab = Random.Range(0, ground.Length);
        //    grounds.Add(Instantiate(ground, transform.position, Quaternion.identity));
        //}
    }

    void Move()
    {
        for (int i = 0; i < grounds.Count; i++)
        {
            grounds[i].transform.position += transform.right * -0.05f;
        }
    }

    void Vanish()
    {
        if (grounds[0].transform.position.x < -10)
        {
            Destroy(grounds[0]);
            grounds.RemoveAt(0);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        grounds.Add(Instantiate(ground, transform.position, Quaternion.identity));

    }
}