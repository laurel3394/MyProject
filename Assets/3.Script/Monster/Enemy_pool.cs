using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_pool : MonoBehaviour
{
    //public float AliveTime = 0f;     //자살프로토콜
    [SerializeField]private float CreatTime = 0f;
    [SerializeField]private float CreatTimer = 0.1f;

    public Transform[] SpawnPoint;
    public GameObject Enemy;
    public Queue<GameObject> Monsterpool = new Queue<GameObject>();

    public float MonsterLevel;                         //몬스터 레벨
    public float MonsterLevelTime;
    public float MonsterLevelTimeMax = 20 * 60f;

    private void Monster_Level()        
    {
        MonsterLevelTime += Time.deltaTime;
        if (MonsterLevelTime > MonsterLevelTimeMax )
        {
            MonsterLevelTime = MonsterLevelTimeMax;
        }
        MonsterLevel = MonsterLevelTime / 60;
    }


    private void Awake()
    {
        SpawnPoint = GetComponentsInChildren<Transform>();
        //몬스터 저장
        for (int i = 0; i < 200; i++)
        {
            GameObject gameObject = Instantiate(Enemy);
            gameObject.SetActive(false);
            Monsterpool.Enqueue(gameObject);
        }
    }
    private void Update()
    {
        CreatTimer += Time.deltaTime;
        //풀링사용
        if (CreatTime < CreatTimer)
        {
            if (MonsterLevel > 0)         // 몬스터 생산 컨트롤
            {
                GameObject pool = Monsterpool.Dequeue();
                if (pool.activeSelf)
                {
                    Monsterpool.Enqueue(pool);

                    pool = Instantiate(Enemy);
                }
                else
                {
                    pool.SetActive(true);
                }

                pool.transform.position = SpawnPoint[Random.Range(1, SpawnPoint.Length)].position;

                //pool.transform.position = new Vector3(UnityEngine.Random.Range(-22f, 22f), UnityEngine.Random.Range(-15f, 15f));

                Monsterpool.Enqueue(pool);

                CreatTimer = 0f;
            }
        }
        Monster_Level();
        if (MonsterLevel > 1)            //몬스터 제거 컨트롤
        {
            gameObject.SetActive(false);
        }



        //AliveTime += Time.deltaTime;             //자살프로토콜
        //if (3f <= AliveTime)
        //{
        //    Destroy(gameObject);
        //}
    }
    //private void OnEnable()
    //{
    //    AliveTime = 0.0f;             //자살프로토콜
    //}
}
