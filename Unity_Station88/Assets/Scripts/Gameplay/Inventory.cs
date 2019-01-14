using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    InventoryObjects[] objectStock;
    InventoryObjects head;
    InventoryObjects arms;
    InventoryObjects accessory;
    InventoryObjects foot;
    InventoryObjects weapon;

	void Start () {
		
	}
	
	void Update () {
		
	}

    void equipItem(InventoryObjects itemToEquip)
    {
        switch (itemToEquip.getType())
        {
            case "head":
                head = itemToEquip;               
                break;
            case "arms":
                arms = itemToEquip;
                break;
            case "accessory":
                accessory = itemToEquip;
                break;
            case "foot":
                foot = itemToEquip;
                break;
            case "weapon":
                weapon = itemToEquip;
                break;
            default:
                addItemToInv(itemToEquip);
                break;
        }
    }

    void addItemToInv(InventoryObjects itemToAdd)
    {
        int i = 0;
        while (objectStock[i])
        {
            Debug.Log("going through inv");
            i++;
        }
        objectStock[i + 1] = itemToAdd;
    }

}
