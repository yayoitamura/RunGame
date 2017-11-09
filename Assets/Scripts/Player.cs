using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveDirection;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //if (controller.isGrounded)
        //{ //地面についているか判定
            if (Input.GetButtonDown("Horizontal"))
            {
                Debug.Log(Input.mousePosition);
                moveDirection.y = 5; //ジャンプするベクトルの代入
                animator.SetTrigger("jump");
            }
        //}

        moveDirection.y -= 10 * Time.deltaTime; //重力計算
        controller.Move(moveDirection * Time.deltaTime); //cubeを動かす処理
    }
}
