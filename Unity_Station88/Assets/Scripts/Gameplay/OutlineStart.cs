using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineStart : MonoBehaviour {

	void Start () {
        Outline ot = GetComponent<Outline>();
        ot.ShowHide_Outline(true);
    }
}
