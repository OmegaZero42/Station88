using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpToSpawnPoint : MonoBehaviour {

    [SerializeField]
    protected GameObject player;
    [SerializeField]
    protected Transform pointToTp;

    void Start () {

    }
	
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.GetComponent<Collider2D>().CompareTag("Player"))
        {
            Debug.Log(this.name + "is colliding with player");
            player.transform.position = pointToTp.position;
        }
    }
}
