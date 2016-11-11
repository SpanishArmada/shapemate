using UnityEngine;
using System.Collections;
using System;

public class GroundTexture : MonoBehaviour {
    public Material baseMaterial;
    private Material groundMaterial;

    // Use this for initialization
    void Start ()
    {
        UpdateTextureScale();
    }
	
	// Update is called once per frame
	void Update () {
    }

    void UpdateTextureScale()
    {
        Renderer renderer = GetComponent<Renderer>();
        double width = renderer.bounds.size.x;
        double height = renderer.bounds.size.y;


        Material groundMaterial = new Material(baseMaterial);
        groundMaterial.mainTextureScale = new Vector2((float)width, (float)height);
        //groundMaterial.mainTextureOffset = new Vector2((float)width % 32, (float)height % 32);

        renderer.material = groundMaterial;
    }

    
}
