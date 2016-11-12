using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public Vector3 maxOffset;

    private Vector3 offset;
    private Vector3 mouseOffset;
    private Vector3 mousePos;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseOffset = getMouseOffset();
        transform.position = player.transform.position + offset - mouseOffset/2;
	}

    Vector3 getMouseOffset()
    {
        Vector3 tmpOffset = player.transform.position - mousePos;
        float dx = Math.Abs(tmpOffset.x);
        float dy = Math.Abs(tmpOffset.y);

        if (dx > maxOffset.x) tmpOffset.x *= maxOffset.x / dx;

        if (dy > maxOffset.y) tmpOffset.y *= maxOffset.y / dy;

        return tmpOffset;
    }
}
