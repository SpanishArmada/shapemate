using UnityEngine;
using System.Collections;

public class EnemyHPManager : MonoBehaviour {

    public GameObject healthBar;
   

    public float enemyHP;

    private Vector3 remainHP;
    private float currentHP;
    private float scale;

    void Start()
    {
        scale = healthBar.transform.localScale.x;
        remainHP = healthBar.transform.localScale;
        currentHP = enemyHP;
    }

    // Use this for initialization
    public bool DealDamage (float damage=1f) {
        currentHP -= damage;
        remainHP.x = scale * (currentHP / enemyHP);
        healthBar.transform.localScale = remainHP;
        if (currentHP <= 0)
        {
            Destroy(healthBar);
            return true;
        }
        return false;
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
