using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
    
    public GameObject ground;
    public GameObject trap;
    private List<GameObject> grounds = new List<GameObject>();

    private void Start()
    {
        Vector3 placePosition = new Vector2(-6.5f, -4.5f);
        for (int i = 0; i < 5; i++)
        {
            grounds.Add(Instantiate(ground, placePosition, Quaternion.identity));
            placePosition.x += 4.7f;

        }

    }

    private void Update()
    {
        switch (GameManager.instance.GAME)
        {
            case GameManager.GAMESTATE.BEGIN:
                Appear();
                Move();
                Vanish();
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
        if (grounds.Count == 0 || grounds[grounds.Count - 1].transform.position.x < 10.5f)
        {
            int currentPrefab = Random.Range(0, grounds.Count);
            grounds.Add(Instantiate(grounds[currentPrefab], transform.position, Quaternion.identity));
        }
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
        if (grounds[0].transform.position.x < -13)
        {
            Destroy(grounds[0]);
            grounds.RemoveAt(0);
        }
    }
}