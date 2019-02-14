using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    [SerializeField]
    protected PlayerPlatformerController player;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<Collider2D>().CompareTag("Player"))
                player.SetCheckpoint(GetComponent<Transform>());
    }
}