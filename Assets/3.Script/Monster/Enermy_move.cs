using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy_move : MonoBehaviour
{
    public float Speed = 1f;
    private SpriteRenderer spriterenderer;
    private Transform PlayerTransForm;
    private Rigidbody2D rigidbody;

    [SerializeField] private float Hp;
    [SerializeField] private float MaxHp;
    [SerializeField] private float Att;


    //public float AliveTime = 0f;     //자살프로토콜

    [SerializeField] private bool isLive;

    private void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        PlayerTransForm = GameObject.Find("Player").transform;
        rigidbody = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {

        //AliveTime += Time.deltaTime;             //자살프로토콜
        //if (3f<=AliveTime)
        //{
        //    gameObject.SetActive(false);
        //}
    }

    private void FixedUpdate()
    {
        if (isLive)
        {

            rigidbody.velocity = Vector2.zero;
            //방향벡터
            Vector3 pos = PlayerTransForm.position - transform.position;

            pos.Normalize();

            spriterenderer.flipX = PlayerTransForm.position.x > transform.position.x;

            transform.position += pos * Time.fixedDeltaTime * Speed;
        
            //아예 플레이어 방향을 보게만들기
            //float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    private void OnEnable()
    {
        //AliveTime = 0.0f;             //자살프로토콜
        isLive = true;
        Hp = MaxHp;
    }

    private void Monster_Dead()
    {        
        gameObject.SetActive(false);
    }


}
