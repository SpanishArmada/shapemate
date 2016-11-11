using UnityEngine;
using System.Collections;

public class EnemyUpDown : MonoBehaviour {

    public float maxUp, maxDown;
    public float speed = (float)0.05;

    public enum VerticalDirection
    {
        Down = -1,
        Up = 1
    };
    public VerticalDirection currentDirection = VerticalDirection.Up;
    private float currentPos;

    // Use this for initialization
    void Start()
    {
        currentDirection = VerticalDirection.Up;
        currentPos = transform.position.y;
    }

    void FixedUpdate()
    {
        CheckChangeDirection();
        Vector3 moveDir = Vector3.zero;
        moveDir.y += (int)currentDirection * speed;
        transform.position += moveDir;
    }

    void CheckChangeDirection()
    {
        currentPos = transform.position.y;

        if (currentDirection == VerticalDirection.Down && currentPos - speed < maxDown)
        {
            currentDirection = VerticalDirection.Up;
        }
        else if (currentDirection == VerticalDirection.Up && currentPos + speed > maxUp)
        {
            currentDirection = VerticalDirection.Down;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
