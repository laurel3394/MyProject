using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public Vector2 inputVec;
    [SerializeField] float Speed;
    Rigidbody2D rigidbody;
    SpriteRenderer renderer;
    Animator animator;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //이동
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        //이동
        Vector2 nextvec = inputVec.normalized * Speed * Time.fixedDeltaTime ;
        rigidbody.MovePosition(rigidbody.position + nextvec);
    }
    private void LateUpdate()
    {
        //플레이어 좌우 애니메이션
        if (inputVec.x != 0)
        {
            renderer.flipX = inputVec.x < 0;
        }
        //stay, move 애니메이션 변경
        animator.SetFloat("Speed", inputVec.magnitude);
    }
}