using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

    public float jumpTakeOffSpeed = 7;
    public float maxSpeed = 7;

    
    private SpriteRenderer spriteRenderer;
    private Transform trsf;
    bool flipOld = true;

    [SerializeField]
    protected GameObject defaultProjectile;
    [SerializeField]
    protected float projectileSpeed = 200;
    [SerializeField]
    protected Transform projSpawn;
    [SerializeField]
    protected Transform projSpawnBis;

    private GameObject[] getCount;
    private bool canShot;

    protected float timeToSpawnProj = 0.5f;
    protected float oldTimeToSpawnProj = 0.5f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        trsf = GetComponent<Transform>();
        if (!projSpawn)
        {
            projSpawn = GameObject.Find("GunPoint").GetComponent<Transform>();
        }
        canShot = true;
    }

    protected override void ComputeVelocity()
    {

        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * .5f;
            }
        }
  
        if (move.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (move.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        flipOld = spriteRenderer.flipX;
        if (move.x == 0)
        {
            spriteRenderer.flipX = flipOld;
        }

        if (Input.GetButtonDown("Fire1") && defaultProjectile)
        {
            GameObject instProj;
            if (spriteRenderer.flipX == false && canShot)
            {
                instProj = Instantiate(defaultProjectile, projSpawn.position, new Quaternion());
                ProjectileMovement projMov = instProj.GetComponent<ProjectileMovement>();
                projMov.flipProj = spriteRenderer.flipX;
            }
            else if (spriteRenderer.flipX == true && canShot)
            {
                instProj = Instantiate(defaultProjectile, projSpawnBis.position, new Quaternion());
                ProjectileMovement projMov = instProj.GetComponent<ProjectileMovement>();
                projMov.flipProj = spriteRenderer.flipX;
            }
        }

        targetVelocity = move * maxSpeed;
    }

    protected override void CheckShoots()
    {
        getCount = GameObject.FindGameObjectsWithTag("ProjectilePlayer");
        if (getCount.Length <= 2)
        {
            canShot = true;
        }
        else
            canShot = false;

    }
}
