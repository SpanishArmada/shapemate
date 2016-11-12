using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	public float minSpeed;
	public float maxFrames;

	private Vector3 target;
	private float speed;

	// Use this for initialization
	void Start () {
		speed = minSpeed * Time.fixedDeltaTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 dist = target - transform.localPosition;
		if (dist.magnitude < speed){
			transform.localPosition = target;

		} else if (dist.magnitude / maxFrames > speed){
			float tempSpeed = dist.magnitude / 3;
			transform.Translate(dist.normalized*tempSpeed);

		} else {
			transform.Translate(dist.normalized*speed);
		}
	}

	public void SetTarget(Vector3 newTarget){
		target = newTarget;
	} 
}
