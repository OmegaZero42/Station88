using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour {

    [SerializeField]
    public int damage;
    public float speed;

    public bool flipProj;
    protected float timeToDisappear = 1;

    protected float defaultSpeed = 10;
    private Vector2 move;
    Rigidbody2D rb2d;
    [SerializeField]
    protected GameObject projToDestroy;

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        if (damage < 1)
            damage = 1;
        
        if (!flipProj)
        {
            move.x = 1;
        }
        else
        {
            move.x = -1;
        }


        rb2d.velocity = move * speed;
    }

    void Update () {
         rb2d.velocity = move * speed;
        timeToDisappear -= Time.deltaTime;
        if (timeToDisappear <= 0)
        {
            GameObject.Destroy(projToDestroy);
        }
	}
}
