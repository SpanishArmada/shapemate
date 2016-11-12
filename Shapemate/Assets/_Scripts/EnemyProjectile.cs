using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {
    public EnemyMovement movement;
    public float projectileSpeed = (float)5.0;
    public float projectileInterval = (float)1.0;
    public float projectileInitialWait = (float)0.0;
    public Rigidbody2D projectile;

    // Use this for initialization
    void Start () {
        InvokeRepeating("LaunchProjectile", projectileInitialWait, projectileInterval);
    }
    
	// Update is called once per frame
	void Update () {
	
	}

    void LaunchProjectile()
    {
        Rigidbody2D instance = Instantiate(projectile);
        instance.position = new Vector2(transform.position.x, transform.position.y);
        instance.velocity = new Vector2((float)movement.currentDirection * projectileSpeed, 0);
    }
}
