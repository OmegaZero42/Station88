using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker_Enemy : MonoBehaviour {

    [SerializeField]
    float walkSpeed;

    [SerializeField]
    int walkDirection = 1;

    [SerializeField]
    protected GameObject projectile;
    [SerializeField]
    protected Transform projSpawn;

    protected SpriteRenderer spriteRenderer;

    bool canShoot = false;
    float timeToShoot;
    float currentTimeToShoot;

    protected Vector2 walkAmount;

    private void Start()
    {
        if (walkSpeed <= 0)
        {
            walkSpeed = 1;
        }
        if (timeToShoot <= 0 && currentTimeToShoot <= 0)
        {
            timeToShoot = 2;
            currentTimeToShoot = 2;
        }
      spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        walkAmount.x = walkDirection * walkSpeed * Time.deltaTime;
        transform.Translate(walkAmount);
        if (canShoot && currentTimeToShoot <= 0 && projectile)
        {
            GameObject instProj = Instantiate(projectile, projSpawn.position, new Quaternion());
            ProjectileMovement projMov = instProj.GetComponent<ProjectileMovement>();
            Physics2D.IgnoreCollision(instProj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            projMov.flipProj = spriteRenderer.flipX;
            instProj.layer = 25;
            canShoot = false;
            currentTimeToShoot = timeToShoot;
        }
        else if (canShoot && currentTimeToShoot > 0)
        {
            currentTimeToShoot -= (1 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Crate")
        {
//            Debug.Log("Colliding with obstacle or crate");
            walkDirection = -walkDirection;
            spriteRenderer.flipX = !spriteRenderer.flipX;
            canShoot = true;
        }
    }
}
