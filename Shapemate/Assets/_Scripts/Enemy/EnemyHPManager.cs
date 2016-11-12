using UnityEngine;
using System.Collections;

public class EnemyHPManager : MonoBehaviour {

    public GameObject enemy;
    public GameObject healthBar;

    public float enemyHP;

    private Vector3 remainHP;
    private float currentHP;
    private float scale;

    void Start()
    {
        scale = transform.localScale.x;
        remainHP = transform.localScale;
        currentHP = enemyHP;
    }

    // Use this for initialization
    public void DealDamage (float damage=1f) {
        currentHP -= damage;
        remainHP.x = scale * (currentHP / enemyHP);
        healthBar.transform.localScale = remainHP;
        if (currentHP <= 0)
        {
            Destroy(enemy);
            Destroy(healthBar);
        }
	}

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            DealDamage(10f);
        }
        
    }

    // Update is called once per frame

}
