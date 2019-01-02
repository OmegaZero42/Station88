using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableItem : MonoBehaviour {

    [SerializeField]
    protected int basePV;
    [SerializeField]
    protected GameObject self;
    protected SpriteRenderer spriteRenderer;

    int currentPV;

	void Start () {
        currentPV = basePV;
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
    }

    private void FixedUpdate()
    {
        Debug.Log(currentPV);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ProjectilePlayer"))
        {
            Debug.Log("colliding with " + collision.collider.name);
            currentPV -= collision.collider.GetComponent<ProjectileMovement>().damage;
            ManageColor();
            if (currentPV <= 0)
                Destroy(self);
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.CompareTag("MeleeAttack"))
        {
            Debug.Log("colliding with " + collision.collider.name);
            currentPV -= collision.collider.GetComponent<MeleeAttack>().damage;
            ManageColor();
            collision.collider.gameObject.SetActive(false);
            if (currentPV <= 0)
                Destroy(self);
            
        }
    }

    protected void ManageColor()
    {
        float pvPercentage = ((float)currentPV / (float)basePV) * 100;
        Debug.Log(currentPV);
        Debug.Log(basePV);
        Debug.Log(pvPercentage);
        if (pvPercentage < 100 && pvPercentage >= 80 )
        {
            spriteRenderer.color = new Color(1 ,0.8f , 0.8f);
        }
        if (pvPercentage < 80 && pvPercentage >= 60)
        {
            spriteRenderer.color = new Color(1, 0.6f, 0.6f);
        }
        if (pvPercentage < 60 && pvPercentage > 20)
        {
            spriteRenderer.color = new Color(1, 0.3f, 0.3f);
        }
        if (pvPercentage <= 20)
        {
            spriteRenderer.color = new Color(1, 0, 0);
        }
    }
}
