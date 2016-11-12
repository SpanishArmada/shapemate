using UnityEngine;
using System.Collections;

public class EnemyHPManager : MonoBehaviour {

    public GameObject enemy;

    private int enemyHP;

    void Start()
    {
        enemyHP = 100;
    }

    // Use this for initialization
    void DealDamage (int damage=1) {
        enemyHP -= damage;
        if(enemyHP <= 0)
        {
            Destroy(enemy);
        }
	}

    void Update()
    {
        
    }

    // Update is called once per frame

}
