using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProjectilesRender : MonoBehaviour {
    public int SquareImage;
    public Sprite SquareSprite;
    private GameObject projectile;
	// Use this for initialization
	void Start () {
        projectile = GameObject.FindGameObjectWithTag("ProjectileCounter");
    }
	
    void FixedUpdate()
    {
        projectile.GetComponent<Text>().text = "5";
    }

    // Update is called once per frame
    void Update () {
	    
	}
}
