using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour
{
    public enum StyleMoveSpace
    {
        PingPong,
        Loop
    }

    public float speedRotation;
    private float _rotationZ;

    public float distancePush;
    public bool movement;
    public StyleMoveSpace styleMoveSpace;
    public float speedMovement;
    public Vector2[] movePosition;
    public int nextPoint = 1;

    private void Update()
    {
        if (speedRotation != 0)
        {
            _rotationZ += speedRotation;
            transform.rotation = Quaternion.Euler(0, 0, _rotationZ);
        }
        if (movement)
        {
            Move();
        }
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePosition[nextPoint], Time.deltaTime * speedMovement);
        if(Vector2.Distance(transform.position, movePosition[nextPoint]) < 0.1f)
        {
            switch (styleMoveSpace)
            {
                case StyleMoveSpace.Loop:
                    if (nextPoint + 1 == movePosition.Length)
                    {
                        transform.position = movePosition[0];
                        nextPoint = 1;
                    }
                    else
                    {
                        nextPoint++;
                    }
                    break;
            }            
        }
    }
}
