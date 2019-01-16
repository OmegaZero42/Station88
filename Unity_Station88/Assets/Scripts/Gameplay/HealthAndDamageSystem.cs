using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthAndDamageSystem : MonoBehaviour
{

    [SerializeField]
    int maxHp;
    int defense;
    [SerializeField]
    int currentHp;
    public int MaxHp
    {
        get
        {
            return maxHp;
        }

        set
        {
            maxHp = value;
        }
    }
    public int CurrentHp
    {
        get
        {
            return currentHp;
        }

        set
        {
            currentHp = value;
        }
    }
    public int Defense
    {
        get
        {
            return defense;
        }

        set
        {
            defense = value;
        }
    }

    void Start()
    {
        if (MaxHp <= 0)
        {
            MaxHp = 100;
        }
        Defense = 0;
        CurrentHp = MaxHp;
    }

    void Update()
    {
        if (CurrentHp <= 0)
        {
            if (this.tag == "Player")
            {
                CurrentHp = MaxHp;
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
                if (!pC.IsTakingDamage && defense - proj.damage < 0)
                {
                    CurrentHp = CurrentHp - (defense - proj.damage);
                }
                pC.IsTakingDamage = true;
            }
        }
    }
}