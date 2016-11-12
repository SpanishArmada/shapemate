using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VisualProjectileController : MonoBehaviour {
	 
	public GameObject sprite;
	public float rotation;
	public float orbitRadius;
	public float yOscillate;
	public float yMultiplier;

	private float currentDeg;
	private float currentYDeg;
	private float rot;
	private float yrot;

	private int currentlyActive;
	private int framecounter;

	List<FollowTarget> children;

	// Use this for initialization
	void Start () {
	}

	public void Init(){
		children = new List<FollowTarget>();
		currentDeg = 0;
		currentYDeg = 0;
		currentlyActive = 0;
		rot = rotation * Time.fixedDeltaTime; 
		yrot = rot*yMultiplier; 
	}

	void FixedUpdate(){
		currentDeg = (currentDeg+rot)%360;
		currentYDeg = (currentYDeg + yrot)%360;
	}

	// Update is called once per frame
	void Update () {
		for (int i=0; i<currentlyActive; ++i){ 
			float degModifier = i*(360/currentlyActive);
			float tempDeg = (currentDeg + degModifier) % 360;
			float tempYDeg = (currentYDeg + degModifier*yMultiplier) % 360;

			Vector3 intendedPosition = new Vector3(Mathf.Sin(tempDeg*Mathf.PI/180) * orbitRadius,
				Mathf.Sin(tempYDeg*Mathf.PI/180) * yOscillate, 
				Mathf.Cos(tempDeg*Mathf.PI/180) * orbitRadius); 
			children[i].SetTarget(intendedPosition);
		}
	}

	public void removeActive(){
		if (currentlyActive > 0){
			children[currentlyActive-1].gameObject.SetActive(false);
			--currentlyActive;
		}
	}

	public void addActive(Vector3 position){
		++currentlyActive;
		if (children.Count < currentlyActive){
			GameObject temp = Instantiate(sprite);
			temp.transform.parent = this.transform;
			children.Add(temp.GetComponent<FollowTarget>());
			children[currentlyActive-1].transform.position = position;
		} else {
			children[currentlyActive-1].gameObject.SetActive(true);
			children[currentlyActive-1].transform.position = position;
		} 
	}
}
