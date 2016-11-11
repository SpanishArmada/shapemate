using UnityEngine;
using System.Collections;

public class EnemyHPManager : MonoBehaviour {

    public GameObject enemy;

    private int enemyHP;

	// Use this for initialization
	void DealDamage (int damage=1) {
        enemyHP -= damage;
        if(enemyHP < 0)
        {
            Destroy(enemy);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
