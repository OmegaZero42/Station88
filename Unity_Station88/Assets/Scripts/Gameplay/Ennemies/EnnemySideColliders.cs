using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnnemySideColliders : MonoBehaviour {

    Collider2D coll;

    [SerializeField]
    EnnemyWalker walker;

    void Start () {
        walker = GetComponentInParent<EnnemyWalker>();
        coll = GetComponent<Collider2D>();
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("coll with " + collider.name);
        if (collider.CompareTag("testPath"))
        {
            switch (walker.Direction)
            {
                case 1:
                    walker.Direction = -1;
                    break;
                case -1:
                    walker.Direction = 1;
                    break;
                default:
                    walker.Direction = 0;
                    break;
            }
        }
    }
}
