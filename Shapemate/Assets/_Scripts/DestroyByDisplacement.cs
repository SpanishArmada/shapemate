using UnityEngine;
using System.Collections;

public class DestroyByDisplacement : MonoBehaviour {
    private float initialPosition;
    // Use this for initialization
    void Start () {
	    initialPosition = transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (System.Math.Abs(transform.position.x - initialPosition) > 50)
        {
            Destroy(gameObject);
        }
    }
}
