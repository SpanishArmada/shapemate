﻿using UnityEngine;
using System.Collections;

public class SquareProjectile : FriendProjectile {

	public float speed;
	public Rigidbody2D rb;
 
	public GameObject spawn;

	private Vector2 target;
	private Vector2 mov;
	private Vector2 initDist;
	private bool fired = false;

	// Use this for initialization
	void Start () { 
		mov = Vector2.zero; 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 cuDist = target - (Vector2)transform.position;   
		if (fired){   
			if (initDist.x * cuDist.x <= 0 && initDist.y * cuDist.y <= 0){ 
				transform.position = target;
				speed = 0;
				rb.velocity = Vector2.zero; 
				fired = false;
				ReachTarget();
			}
		}
	}

	public override void Fire(Vector2 targetPos){ 
		target = targetPos;
		initDist = target - (Vector2)transform.position;
		mov = ((Vector2)(initDist)).normalized * speed;
		rb.velocity = mov; 
		fired = true; 
	}

	public void ReachTarget(){
		GameObject newobj = Instantiate(spawn);
		newobj.transform.position = target;
		Destroy(this.gameObject);
	}
}
