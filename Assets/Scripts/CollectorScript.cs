using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorScript : MonoBehaviour
{

    [SerializeField]
    private PlayerScript player;
    [SerializeField]
    private LogicScript logic;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Item"))
        {
            Destroy(other.gameObject);
            player.gotTheKey();
        } else 
        
        if (other.gameObject.tag.Equals("Portal"))
        {
            Debug.Log(other.gameObject.tag);
            if (player.hasTheKey())
            {
                logic.gameOver();
                player.disableMovement();
            }
        } 
    }
}
