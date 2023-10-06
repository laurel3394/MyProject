using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public Player_move player;

    public float GameTime;
    public float MaxGameTime = 2 *10f;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        GameTime += Time.deltaTime;
        if (GameTime > MaxGameTime)
        {
            GameTime = MaxGameTime;
        }
    }


}
