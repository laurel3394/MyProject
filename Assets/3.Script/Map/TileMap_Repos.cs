using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap_Repos : MonoBehaviour
{
    Collider2D coll;
    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 platerPos = Gamemanager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        float difX = Mathf.Abs(platerPos.x - myPos.x);
        float difY = Mathf.Abs(platerPos.y - myPos.y);

        Vector3 playerDir = Gamemanager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                //그라운드 이동
                if (difX > difY)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (difX < difY)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            case "Enemy":
                //몬스터 이동 
                if (coll.enabled)
                {
                    transform.Translate(playerDir * 23 + new Vector3(Random.Range(-3f,3f),Random.Range(-3f,3f),0f));
                }
                break;

        }

    }
}
