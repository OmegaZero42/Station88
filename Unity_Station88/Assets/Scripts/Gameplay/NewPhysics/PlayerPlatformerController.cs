using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

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

    private bool isTakingDamage;

    protected float timeToSpawnProj = 0.5f;
    protected float oldTimeToSpawnProj = 0.5f;
    protected float currentHp;

    private GameObject self;

    private void Start()
    {
        self = GetComponent<GameObject>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        trsf = GetComponent<Transform>();
        if (!projSpawn)
        {
            projSpawn = GameObject.Find("GunPoint").GetComponent<Transform>();
        }
        canShot = true;

        meleeAttackPower = 1;
        distanceAttackPower = 1;
        speedPower = 1;
        defensePower = 1;
        hp = 100;
        currentHp = hp;
        isTakingDamage = false;

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


        Debug.Log("hp =" + hp);
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
        if (collision.collider.tag == "Projectile")
        {
            Physics2D.IgnoreCollision(collision.collider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            ProjectileMovement proj = collision.collider.GetComponent<ProjectileMovement>();
            hp = hp - proj.damage;
            isTakingDamage = true;
            Destroy(collision.collider.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "ProjectilePlayer")
        {
            Physics2D.IgnoreCollision(collision.collider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (collision.collider.tag == "Projectile")
        {
            Physics2D.IgnoreCollision(collision.collider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    private void FixedUpdate()
    {
        if (hp <= 0)
            Application.Quit();
    }
}
