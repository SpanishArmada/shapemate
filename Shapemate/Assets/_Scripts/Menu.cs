using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public GameObject loadingImage;
    public void loadStage(int stage)
    {
        loadingImage.SetActive(true);
        Application.LoadLevel(stage);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
