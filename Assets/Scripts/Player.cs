using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
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
            transform.position += transform.right * 0.08f;
            if (transform.position.x > -3.5)
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