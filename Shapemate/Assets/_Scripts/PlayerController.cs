using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D objectRb;
	public GameObject sprite;
    public bool movingRight = true;
    public bool grounded = true;
    public float speed = 10.0f;
    public float jumpSpeed = 20.0f;
    public float gravity = 35.0f;
    public float yPosition = 0.0f;
    public bool falling = false;
    public bool isDeath = false;
    public PlayerHPManager selfHP;
    private Vector2 latestCheckPoint = new Vector2(0.0f, 0.0f);


    // Use this for initialization
    void Start()
    {
        yPosition = objectRb.transform.position.y;
    }

    void FixedUpdate()
    {
        objectRb.velocity = new Vector2(objectRb.velocity.x, objectRb.velocity.y - gravity * Time.deltaTime);
        if (objectRb.transform.position.y <= -10)
            isDeath = true;
        if(isDeath)
        {
            objectRb.transform.position = latestCheckPoint;
            objectRb.velocity = new Vector2(0, -20);
            selfHP.ResetHealth();
            isDeath = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            objectRb.velocity = new Vector2(0, objectRb.velocity.y);
        if (Input.GetKey(KeyCode.A))
        {
            if (movingRight)
                movingRight = false;
            objectRb.velocity = new Vector2(-speed, objectRb.velocity.y);
            //objectRb.AddForce(new Vector2(-5, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (!movingRight)
                movingRight = true;
            objectRb.velocity = new Vector2(speed, objectRb.velocity.y);
            //objectRb.AddForce(new Vector2(5, 0));
        }
        if (Input.GetKey(KeyCode.W) && grounded)
        {
            objectRb.velocity = new Vector2(objectRb.velocity.x, jumpSpeed);
            grounded = false;
        }

		if (!movingRight && sprite.transform.localScale.x > 0)
        {
			sprite.transform.localScale += new Vector3(-2 * sprite.transform.localScale.x, 0, 0);
        }
		else if (movingRight && sprite.transform.localScale.x < 0)
        {
			sprite.transform.localScale += new Vector3(-2 * sprite.transform.localScale.x, 0, 0);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
            grounded = true;

        if (col.gameObject.tag == "Enemy")
        {
            // reduce hp here
            if (selfHP.DealDamage(10f))
            {
                isDeath = true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "CheckPoint")
		{
			print("IN");
			latestCheckPoint = col.gameObject.transform.position;
			PlayerProjectileController projController = this.gameObject.GetComponentInChildren<PlayerProjectileController>();
			projController.AddAmmo();
			Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Projectile")
        {
            Destroy(col.gameObject);
            // reduce hp here
            if (selfHP != null && selfHP.DealDamage(10f))
            {
                isDeath = true;
            }
        }
        if (col.gameObject.tag == "Enemy")
        {
            // reduce hp here
            if (transform.position.y > col.transform.position.y + 0.5)
            {
                col.gameObject.GetComponent<EnemyController>().Kill();
                objectRb.velocity = new Vector2(objectRb.velocity.x, jumpSpeed);
                grounded = false;
            }else
            {
                if (selfHP.DealDamage(10f))
                {
                    isDeath = true;
                }
            }
            
        }
        if (col.gameObject.tag == "EnemyTop")
        {
            //if(transform.position.y > col.transform.position.y + 0.5)
            //{
            //    Destroy(col.gameObject);
            //    objectRb.velocity = new Vector2(objectRb.velocity.x, jumpSpeed);
            //    grounded = false;
            //}
            
        }
        if (col.gameObject.tag == "EnemyHP")
        {
            if (transform.position.y > col.transform.position.y + 0.2)
            {
                objectRb.velocity = new Vector2(objectRb.velocity.x, jumpSpeed);
                grounded = false;
            }
        }
        if(col.gameObject.tag == "Finish")
        {
            Application.LoadLevel(3);
        }

    }
}
