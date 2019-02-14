using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {


    [SerializeField]
    public int damage;

    [SerializeField]
    GameObject Player;

    protected float timeToDisappear = 1;
    [SerializeField]
    protected GameObject AttackToDestroy;

    void Start()
    {
    }

    void Update()
    {
        timeToDisappear -= Time.deltaTime;
        if (timeToDisappear <= 0)
        {
            Destroy(AttackToDestroy);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(AttackToDestroy);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Destroy(AttackToDestroy);
    }
}
