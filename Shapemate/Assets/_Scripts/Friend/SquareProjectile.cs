using UnityEngine;
using System.Collections;

public class SquareProjectile : FriendProjectile {

	public float speed;
	public Rigidbody2D rb;

	private Vector2 pos;
	private Vector2 target;
	private Vector2 mov;
	private Vector2 initDist;
	private bool fired;

	// Use this for initialization
	void Start () {
		Debug.Log("AAA");
		pos = transform.position;
		mov = Vector2.zero;
		fired = false;
		Fire(new Vector2(10,10));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 cuDist = target - (Vector2)transform.position; 
		if (fired){ 
			if (initDist.x * cuDist.x <= 0 && initDist.y * cuDist.y <= 0){
				transform.position = target;
				speed = 0;
				rb.velocity = Vector2.zero; 
			}
		}
	}

	protected void Fire(Vector2 targetPos){
		target = targetPos;
		initDist = target-pos;
		mov = ((Vector2)(initDist)).normalized * speed;
		rb.velocity = mov; 
		fired = true;
	}
}
