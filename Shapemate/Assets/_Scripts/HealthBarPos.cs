using UnityEngine;
using System.Collections;

public class HealthBarPos : MonoBehaviour {

    public GameObject obj;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - obj.transform.position;
        //offset.y += 1.5f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = obj.transform.position + offset;
    }
}
