using UnityEngine;
using System.Collections;

public class PlayerProjectileController : MonoBehaviour {

	public GameObject projectile;

	private bool firing;
	private Vector2 target;

	// Use this for initialization
	void Start () {
		firing=false;
	}
		
	void FixedUpdate(){
		if (firing){ 
			DoAction();
			firing=false;
		}
	}

	// Update is called once per frame
	void Update () { 
		if (Input.GetMouseButtonUp(0)){ 
			firing = true;
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}

	void DoAction(){
		GameObject newProj = GameObject.Instantiate(projectile);
		newProj.transform.position = this.transform.position;
		FriendProjectile t = newProj.GetComponent<SquareProjectile>(); 
		t.Fire(target);
	}
}
