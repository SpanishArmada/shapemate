using UnityEngine;
using System.Collections;

public class ParralaxScroll : MonoBehaviour {
    public Transform playerPos;
    public float parallaxFactor;
    private float offset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3((playerPos.position.x*parallaxFactor), GetComponent<Renderer>().transform.position.y, GetComponent<Renderer>().transform.position.z);
        if (GetComponent<Renderer>().material.mainTextureOffset.x > 1.0f)
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(GetComponent<Renderer>().material.mainTextureOffset.x - 1.0f, 
                GetComponent<Renderer>().material.mainTextureOffset.y);

    }
}
