using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
    
    public GameObject ground;
    public GameObject trap;
    public GameObject[] groundPatternPrefabs;
    private List<GameObject> grounds = new List<GameObject>();
    private int trapCount;
    const int MAX_TRAP = 2;
    const int GROUND = 0;
    const int TRAP = 1;

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
                Appear(GROUND);
                Move();
                Vanish();
                break;
            case GameManager.GAMESTATE.PLAY:
                int prefabIndex = Random.Range(0, groundPatternPrefabs.Length);
                Appear(prefabIndex);
                Move();
                Vanish();
                break;
            case GameManager.GAMESTATE.END:
                endGame();
                break;
        }
    }

    void Appear(int prefabIndex)
    {
        if (grounds.Count == 0 || grounds[grounds.Count - 1].transform.position.x < 10.5f)
        {
            if (prefabIndex == 0)
            {
                trapCount++;
            }
            if (prefabIndex == 1)
            {
                trapCount = 0;
            }
            if (trapCount > MAX_TRAP)
            {
                prefabIndex = 1;
            }
            grounds.Add(Instantiate(groundPatternPrefabs[prefabIndex], transform.position, Quaternion.identity));
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

    void endGame()
    {
        Debug.Log("endGame");
    }
}