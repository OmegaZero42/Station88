using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class EnnemyBasics : PhysicsObject {

    protected bool isMoving = false;
    protected bool doesAttack = false;
    protected bool doesJump = false;
    protected float speed;
    protected float attack;
    protected float defense;
    protected string weakness;

    protected Rigidbody2D localRb2d;
    protected Collider2D localCollider;

    public virtual void Start () {
        localRb2d = GetComponent<Rigidbody2D>();
        localCollider = GetComponent<Collider2D>();
    }
}
