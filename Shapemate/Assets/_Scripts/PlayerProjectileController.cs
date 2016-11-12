using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerProjectileController : MonoBehaviour {

	public GameObject projectile;
	public GameObject ammoManager;
	public int maxAmmo;
	public VisualProjectileController visController;

	private int remainingAmmo;
	private bool firing;
	private bool reloading;
	private Vector2 target;
	private List<FriendProjectile> liveAmmo;

	// Use this for initialization
	void Start () {
		firing = false;
		remainingAmmo = maxAmmo;
		visController.Init();
		for (int i=0; i<remainingAmmo; ++i){
			visController.addActive(new Vector3(0,0,0));
		}
	}
		
	void FixedUpdate(){
		if (firing){
			Debug.Log("Firing");
			if (remainingAmmo > 0){
				DoAction();
				visController.removeActive();
				remainingAmmo -= 1;
			}
			firing=false;
		}
		if (reloading){
			ResetAllAmmo();
			remainingAmmo = maxAmmo;
			reloading=false;
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
		t.gameObject.transform.parent = ammoManager.transform; 

		t.Fire(target);
	}

	void ResetAllAmmo(){
		Debug.Log("Delete");
		foreach (Transform child in ammoManager.transform){
			visController.addActive(child.position);
			Destroy(child.gameObject);
		}
	}

	public void AddAmmo(){
		++maxAmmo;
		visController.addActive(new Vector3(0,0,0));
	}
}
