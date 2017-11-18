using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ←※これを忘れずに入れる


public class Player : MonoBehaviour 
{
    private Vector3 moveDirection;
    private Animator animator;
    private float flap = 400f;
    private Rigidbody rb;
    private GameObject button;
    private int jumpCount;

    private float hp;
    private int score = 000000;

    Slider slider;
    Image image;
    Text scoreText;

    enum STATE
    {
        WAIT,
        RUN,
        JUMP,
    };

    private STATE state = STATE.WAIT;

    void Start()
    {
        //GameState.GameState;

        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        button = GameObject.Find("Button");
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
        button.SetActive(false);
        animator.SetTrigger("run");

        scoreText.text = score.ToString();
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
        

    }


    public void Dead() 
    {
        GameManager.instance.GAME = GameManager.GAMESTATE.END;

        button.SetActive(true);
        //this.gameObject.SetActive(false);    
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            score += 1;
            scoreText.text = score.ToString();
        }

        if (other.gameObject.tag == "HpItem")
        {
            hp += 10;
        }
    }
}


/*
 * 
 * 
 * 
 * 
 * 
 * public class Player : MonoBehaviour {
    private Vector3 moveDirection;
    private Animator animator;
    private float flap = 400f;
    private Rigidbody rb;
    private GameObject button;
    private string state = "idle";

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        button = GameObject.Find("Button");
    }

    void Update()
    {
        if (state == "run")
        {
            transform.position += transform.right * 0.09f;
            if (transform.position.x > -3)
            {
                state = "Start";
            }
        }
        if (Input.GetButtonDown("Horizontal"))
        {
            Debug.Log(Input.mousePosition);
            animator.SetTrigger("jump");
            rb.AddForce(Vector2.up * flap);
        }
    }

    public void StartGame()
    {
        state = "run";
        button.SetActive(false);
        animator.SetTrigger("run");
    }

    public void Dead() 
    {
        button.SetActive(true);
        //this.gameObject.SetActive(false);    
    }
}
 * 
 * 
 * 
 * 
 * 
 * 
 */