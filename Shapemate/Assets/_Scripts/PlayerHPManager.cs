using UnityEngine;
using System.Collections;

public class PlayerHPManager : MonoBehaviour
{

    public GameObject self;
    public GameObject healthBar;

    public float playerHP;

    private Vector3 remainHP;
    public float currentHP;
    private float scale;

    void Start()
    {
        scale = healthBar.transform.localScale.x;
        remainHP = healthBar.transform.localScale;
        currentHP = playerHP;
    }

    // Use this for initialization
    public bool DealDamage(float damage = 10f)
    {
        currentHP -= damage;
        remainHP.x = scale * (currentHP / playerHP);
        healthBar.transform.localScale = remainHP;
        if (currentHP <= 0)
        {
            
            return true;
        }
        return false;
    }

    public void ResetHealth()
    {
        currentHP = playerHP;
        remainHP.x = scale * (currentHP / playerHP);
        healthBar.transform.localScale = remainHP;
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
