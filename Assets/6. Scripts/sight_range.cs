﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sight_range : MonoBehaviour
{
    public Enemy_ai enemy_ai;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Leader")
        {
            enemy_ai.enemy_state = e_state.attack_ready;      // attack range 안에 player 감지시 
            enemy_ai.player = collision.gameObject;
            enemy_ai.move_false();
            if (enemy_ai.code == 101)                        // 구미호는 attak range와 sight rage가 같아서 따로 이부분만 sight range에 넣어줌
            {
                enemy_ai.inrange = true;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Leader")
        {
            enemy_ai.enemy_state = e_state.Follow;      // attack range 밖으로 player 벗어남
            enemy_ai.move_true();
            enemy_ai.player = null;
            if (enemy_ai.code == 101)
            {
                enemy_ai.inrange = false;
            }
        }

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
