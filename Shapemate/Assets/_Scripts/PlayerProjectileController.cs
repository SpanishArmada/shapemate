using UnityEngine;
using System.Collections;

public class PlayerProjectileController : MonoBehaviour {

	public GameObject projectile;
	public int maxAmmo;

	private int remainingAmmo;
	private bool firing;
	private bool reloading;
	private Vector2 target;

	// Use this for initialization
	void Start () {
		firing = false;
		remainingAmmo = maxAmmo;
	}
		
	void FixedUpdate(){
		if (firing){ 
			DoAction();
			firing=false;
			remainingAmmo -= 1;
		}
		if (reloading){
			ResetAllAmmo();
			remainingAmmo = maxAmmo;
		}
	}

	// Update is called once per frame
	void Update () { 
		if (Input.GetMouseButtonUp(0)){ 
			firing = true;
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		if (Input.GetKeyDown(KeyCode.Space)){
			reloading = true;
		}
	}

	void DoAction(){
		GameObject newProj = GameObject.Instantiate(projectile);
		newProj.transform.position = this.transform.position;
		FriendProjectile t = newProj.GetComponent<SquareProjectile>(); 
		t.Fire(target);
	}

	void ResetAllAmmo(){
	
	}
}
