using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    InventoryObjects[] objectStock;
    InventoryObjects head;
    InventoryObjects arms;
    InventoryObjects accessory;
    InventoryObjects foot;
    InventoryObjects weapon;

    [SerializeField]
    Image headImage;
    [SerializeField]
    Image armsImage;
    [SerializeField]
    Image accessoryImage;
    [SerializeField]
    Image footImage;
    [SerializeField]
    Image weaponImage;

    void Start () {

    }
	
	void Update () {
		
	}

    string equipItem(InventoryObjects itemToEquip)
    {
        switch (itemToEquip.getType())
        {
            case "head":
                head = itemToEquip;
                headImage.sprite = itemToEquip.getSprite().sprite;
                return ("head");
            case "arms":
                arms = itemToEquip;
                armsImage.sprite = itemToEquip.getSprite().sprite;
                return ("arms");
            case "accessory":
                accessory = itemToEquip;
                accessoryImage.sprite = itemToEquip.getSprite().sprite;
                return ("accessory");
            case "foot":
                foot = itemToEquip;
                footImage.sprite = itemToEquip.getSprite().sprite;
                return ("foot");
            case "weapon":
                weapon = itemToEquip;
                weaponImage.sprite = itemToEquip.getSprite().sprite;
                return ("weapon");
            default:
                addItemToInv(itemToEquip);
                return ("error");
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "InvObject")
        {
            InventoryObjects toEquip = collider.GetComponent<InventoryObjects>();
            equipItem(toEquip);
            GameObject toDestroy = collider.GetComponent<GameObject>();
            Destroy(toDestroy);
        }
    }
}
