using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

    public float jumpTakeOffSpeed = 7;
    public float dashSpeed = 5;
    public float maxSpeed = 7;
    
    private SpriteRenderer spriteRenderer;
    private Transform trsf;
    bool flipOld = true;

    [SerializeField]
    protected LayerMask layerMask;
    [SerializeField]
    protected GameObject defaultProjectile;
    [SerializeField]
    protected float projectileSpeed = 200;
    [SerializeField]
    protected Transform projSpawn;
    [SerializeField]
    protected Transform projSpawnBis;

    [SerializeField]
    protected GameObject HitboxMelee;
    [SerializeField]
    protected GameObject HitboxMelee2;


    private GameObject[] getCount;
    private bool canShot;

    protected float timeToSpawnProj = 0.5f;
    protected float oldTimeToSpawnProj = 0.5f;

    public bool IsTakingDamage;
    public float takingDamageTime;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        trsf = GetComponent<Transform>();
        if (!projSpawn)
        {
            projSpawn = GameObject.Find("GunPoint").GetComponent<Transform>();
        }
        canShot = true;

        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(layerMask));
        contactFilter.useLayerMask = true;
        IsTakingDamage = false;
        takingDamageTime = 5f;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (IsTakingDamage && takingDamageTime > 0)
            takingDamageTime--;
        else if (IsTakingDamage && takingDamageTime <= 0)
        {
            IsTakingDamage = false;
            takingDamageTime = 5f;
        }
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (!IsTakingDamage)
        {
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
            if (Input.GetButtonDown("Dash") && grounded)
            {
                move.x = move.x * dashSpeed;
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

            if (Input.GetButtonDown("Fire2"))
            {
                if (spriteRenderer.flipX == false)
                {
                    HitboxMelee.SetActive(true);
                }
                else if (spriteRenderer.flipX == true)
                {
                    HitboxMelee2.SetActive(true);
                }
            }
        }
        else if (IsTakingDamage)
        {
            float datWay = -1f;
            if (flipOld)
                datWay = 1f;
            move = new Vector2(datWay, 0)*0.7f;
            velocity = new Vector2(0, 1) * maxSpeed*0.7f;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ProjectilePlayer")
        {
            Physics2D.IgnoreCollision(collision.collider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
