﻿using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public EnemyMovement thisMovement;
    public EnemyUpDown thisUpDown;
    public EnemyHPManager thisHP;
    public Rigidbody2D thisRB;

    private bool isDeath;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isDeath)
        {
            gameObject.layer = 9;

            if(thisMovement!=null)
                thisMovement.speed = 0;

            if(thisRB!=null)
                thisRB.velocity = new Vector2(thisRB.velocity.x, thisRB.velocity.y - 35 * Time.deltaTime);
        }
        if(transform.position.y < -100)
        {
            Destroy(gameObject);
        }
        
    }

    public void Kill()
    {
        isDeath = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Change to Triangle Tag
        //if (col.gameObject.tag == "Player")
        //{
        //    // reduce hp here
        //    if (thisHP != null && thisHP.DealDamage(10f))
        //    {
        //        isDeath = true;
        //    }
        //}
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            // reduce hp here
            if (transform.position.y + 0.2 < col.transform.position.y)
            {
                if (thisHP != null && thisHP.DealDamage(10f))
                {
                    isDeath = true;
                }
            }
               
        }
    }
}
