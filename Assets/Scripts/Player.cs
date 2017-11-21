using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ←※これを忘れずに入れる


public class Player : MonoBehaviour 
{
    public GameObject gameOver;
    private Animator animator;
    private float flap = 400f;
    private Rigidbody2D rb;
    private GameObject button;
    private int jumpCount;

    private float hp;
    private int score = 000000;

    Slider slider;
    Image image;
    Text scoreText;
    Text buttonText;
    Text highScoreText;

    private int highScore;
    private string highScoreKey = "highScore";

    enum STATE
    {
        WAIT,
        RUN,
        JUMP,
    };

    private STATE state = STATE.WAIT;

    void Start()
    {
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();

        button = GameObject.Find("Button");
        buttonText = button.gameObject.GetComponentInChildren<Text>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();

        // スライダーを取得する
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        image = GameObject.Find("Fill").GetComponent<Image>();
        hp = slider.maxValue;
    }

    void Update()
    {
        switch (GameManager.instance.GAME)
        {
            case GameManager.GAMESTATE.BEGIN:
                break;
            case GameManager.GAMESTATE.PLAY:
                PlayGame();
                break;
            case GameManager.GAMESTATE.END:
                EndGame();
                break;
        }
    }

    public void StartGame()
    {
        image.color = Color.green;

        hp = slider.maxValue;
        GameManager.instance.GAME = GameManager.GAMESTATE.PLAY;
        gameOver.SetActive(false);
        button.SetActive(false);
        animator.SetTrigger("run");
        highScore = PlayerPrefs.GetInt("highScoreKey",0);

        score = 0;
        scoreText.text = string.Format("{0:D6}", score);
    }
    void BeginGame()
    {
        
    }
    void PlayGame()
    {
        switch (state)
        {
            case STATE.WAIT:
                transform.position += transform.right * 0.08f;
                if (transform.position.x > -3.5)
                {
                    state = STATE.RUN;
                }
                break;
            case STATE.RUN:
                DecreaseHp();
                if (Input.GetButtonDown("Horizontal") && jumpCount < 2)
                {
                    state = STATE.JUMP;
                }
                break;
            case STATE.JUMP:
                DecreaseHp();
                animator.SetTrigger("jump");
                rb.AddForce(Vector2.up * flap);
                jumpCount++;
                state = STATE.RUN;
                break;
        }
    }

    void DecreaseHp()
    {
        // HP減少
        hp -= Time.deltaTime;
        //HPが残り少なくなると赤色に
        if (hp < slider.maxValue / 5)
        {
            image.color = Color.red;
            if (hp < slider.minValue)
            {
                Dead();
            }
        }
        // HPゲージに値を設定
        slider.value = hp;
    }

    void EndGame()
    {
        gameOver.SetActive(true);
        highScoreText = GameObject.Find("HighScore").gameObject.GetComponentInChildren<Text>();
        highScoreText.text = "High Score:" + highScore +  "\nScore:" + score;

        buttonText.text = "もういちど";
        button.SetActive(true);

        GameManager.instance.GAME = GameManager.GAMESTATE.BEGIN;
    }


    public void Dead() 
    {
        GameManager.instance.GAME = GameManager.GAMESTATE.END;
        Save();

        //this.gameObject.SetActive(false);    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Item")
        {
            score += 100;
            scoreText.text = string.Format("{0:D6}", score);
        }

        if (other.gameObject.tag == "HpItem")
        {
            hp += 10;
        }
    }

    // ハイスコアの保存
    public void Save()
    {
        highScore = Mathf.Max(highScore, score);
        // ハイスコアを保存する
        PlayerPrefs.SetInt("highScoreKey", highScore);
        PlayerPrefs.Save();
    }

}