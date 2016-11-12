using UnityEngine;
using System.Collections;

public class EnemyChasePlayer : EnemyMovement {
    public GameObject player;

    private Direction previousDirection;

	// Use this for initialization
	void Start () {
        currentDirection = Direction.Left;
    }

    void FixedUpdate()
    {
        previousDirection = currentDirection;
        CheckChangeDirection();

        Vector3 moveDir = Vector3.zero;
        moveDir.x += (int)currentDirection * speed;
        Vector3 resultantPosition = transform.position + moveDir;

        if (minLeft <= resultantPosition.x && resultantPosition.x <= maxLeft)
            // in boundary of minLeft and maxLeft
        {
            transform.position = resultantPosition;
        }
        if (previousDirection == currentDirection)
        {
            return;
        }

        // face left or right
        Vector3 objDir = transform.localScale;
        objDir.x = transform.localScale.x * -1;
        transform.localScale = objDir;
    }

    void CheckChangeDirection()
    {
        //Debug.Log(transform.position.x + " " + player.transform.position.x);
        if (player.transform.position.x < transform.position.x)
        {
            currentDirection = Direction.Left;
        }
        else
        {
            currentDirection = Direction.Right;
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
