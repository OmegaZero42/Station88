using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObjects : MonoBehaviour {

    [SerializeField]
    string itemType;
    [SerializeField]
    int attackBonus;
    [SerializeField]
    int defenseBonus;

    public int AttackBonus
    {
        get
        {
            return attackBonus;
        }

        set
        {
            attackBonus = value;
        }
    }

    public int DefenseBonus
    {
        get
        {
            return defenseBonus;
        }

        set
        {
            defenseBonus = value;
        }
    }

    void Start () {
        if (!"head arms accessory foot weapon".Contains(itemType))
        {
            Debug.LogError("Item creation failed");
        }
	}


    public string getType()
    {
        return(itemType);
    }
}
