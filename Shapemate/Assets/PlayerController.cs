using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public Rigidbody2D objectRb;

	// Use this for initialization
	void Start () {
	    
	}
	
    void FixedUpdate()
    {

    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.D))
        {
            objectRb.AddForce(new Vector2(1, 1));
        }
    }
}
