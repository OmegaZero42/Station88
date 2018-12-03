using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthAndDamageSystem : MonoBehaviour
{

    [SerializeField]
    float maxHp;
    float defense;
    float currentHp;

    void Start()
    {
        if (maxHp <= 0)
        {
            maxHp = 100;
        }
        defense = 0;
        currentHp = maxHp;
    }

    void Update()
    {
        Debug.Log("current hp =" + currentHp);
        if (currentHp <= 0)
        {
            if (this.tag == "Player")
            {
                currentHp = maxHp;
                SceneManager.LoadScene(1);
            }
            else
            {
                GameObject.Destroy(this.GetComponent<GameObject>());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Projectile")
        {
            ProjectileMovement proj = collision.collider.GetComponent<ProjectileMovement>();
            Debug.Log("took -" + proj.damage + " hp");
            
            //on chope le playercontroller, et on active le recul du aux dommages
            if (this.tag == "Player")
            {
                PlayerPlatformerController pC = this.GetComponent<PlayerPlatformerController>();
                if (!pC.IsTakingDamage)
                    currentHp = currentHp - proj.damage;
                pC.IsTakingDamage = true;
            }
        }
    }
}