using UnityEngine;
using System.Collections;

public class Stage2Done : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(gameObject == null || gameObject.GetComponent<EnemyHPManager>().currentHP <= 0f)
            Application.LoadLevel(4);
    }
}
