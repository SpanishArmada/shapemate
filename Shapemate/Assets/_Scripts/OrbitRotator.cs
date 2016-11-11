using UnityEngine;
using System.Collections;

public class OrbitRotator : MonoBehaviour {

	public float initialDegree;
	public float rotation;
	public float orbitRadius;
	public float yOscillate;

	private float currentDeg;
	private float currentYDeg;
	private float rot;
	private float yrot;

	// Use this for initialization
	void Start () {
		currentDeg = initialDegree;
		currentYDeg = initialDegree;
		rot = rotation * Time.fixedDeltaTime; 
		yrot = rot/3;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		currentDeg = (currentDeg + rot) % 360;
		currentYDeg = (currentYDeg + yrot) % 360;
		transform.position = new Vector3(Mathf.Sin(currentDeg*Mathf.PI/180) * orbitRadius,
										1+Mathf.Sin(currentYDeg*Mathf.PI/180) * yOscillate, 
										Mathf.Cos(currentDeg*Mathf.PI/180) * orbitRadius);
	}
}
