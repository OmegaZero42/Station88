using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {


    [SerializeField]
    public int damage;

    protected float timeToDisappear = 1;
    [SerializeField]
    protected GameObject AttackToDestroy;

    void Start()
    {
        if (damage < 10)
            damage = 10;
    }

    void Update()
    {
        timeToDisappear -= Time.deltaTime;
        if (timeToDisappear <= 0)
        {
            AttackToDestroy.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AttackToDestroy.SetActive(false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        AttackToDestroy.SetActive(false);
    }
}
