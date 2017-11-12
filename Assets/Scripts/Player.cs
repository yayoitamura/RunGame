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

    private float hp;

    Slider slider;
    Image image;

    enum STATE
    {
        RUN,
        JUMP,
        START,
    };
    private STATE state = STATE.RUN;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        button = GameObject.Find("Button");

        // スライダーを取得する
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        image = GameObject.Find("Fill").GetComponent<Image>();
        //player = GameObject.Find("Player").GetComponent<Player>();
        hp = slider.maxValue;
    }

    void Update()
    {
        if (state == STATE.RUN)
        {
            transform.position += transform.right * 0.08f;
            if (transform.position.x > -3.5)
            {
                state = STATE.START;
            }
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            Debug.Log(Input.mousePosition);
            animator.SetTrigger("jump");
            rb.AddForce(Vector2.up * flap);
        }

        // HP上昇
        hp -= 0.02f;
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

    public void StartGame()
    {
        state = STATE.RUN;
        button.SetActive(false);
        animator.SetTrigger("run");
    }

    public void Dead() 
    {
        button.SetActive(true);
        //this.gameObject.SetActive(false);    
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