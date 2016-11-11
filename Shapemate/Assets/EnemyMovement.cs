using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
    public float minLeft, maxLeft;
    public float speed = (float)0.05;

    public enum Direction {
        Left = -1,
        Right = 1
    };
    public Direction currentDirection = Direction.Left;
    private float currentLeft;

	// Use this for initialization
	void Start () {
        currentDirection = Direction.Left;
        currentLeft = transform.position.x;
    }

    void FixedUpdate()
    {
        CheckChangeDirection();
        Vector3 moveDir = Vector3.zero;
        moveDir.x += (int)currentDirection * speed;
        transform.position += moveDir;
    }

    void CheckChangeDirection()
    {
        currentLeft = transform.position.x;

        if (currentDirection == Direction.Left && currentLeft - speed < minLeft)
        {
            currentDirection = Direction.Right;
        }
        else if (currentDirection == Direction.Right && currentLeft + speed > maxLeft)
        {
            currentDirection = Direction.Left;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
