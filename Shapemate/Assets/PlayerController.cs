using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D objectRb;
    public bool movingRight = true;
    public bool grounded = true;
    public float speed = 10.0f;
    public float jumpSpeed = 20.0f;
    public float gravity = 35.0f;
    public float yPosition = 0.0f;
    public bool falling = false;
    public bool isDeath = false;
    
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
            GameObject checkPoint = GameObject.FindGameObjectsWithTag("CheckPoint")[0];
            objectRb.transform.position = new Vector2(checkPoint.transform.position.x, 4);
            objectRb.velocity = new Vector2(0, -20);
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

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
            grounded = true;
        if (col.gameObject.tag == "Enemy")
            isDeath = true;
    }
}
