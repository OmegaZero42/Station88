using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyWalker : EnnemyBasics {

    private int direction = 1;
    public int Direction
    {
        get
        {
            return direction;
        }

        set
        {
            direction = value;
        }
    }

    public override void Start () {
        base.Start();
        isMoving = true;
        speed = 0.5f;
        Direction = 1;
	}

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        move.x = Direction;
        targetVelocity = move * speed;
    }
}
