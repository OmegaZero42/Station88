using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    PlayerPlatformerController player;

    InventoryObjects[] objectStock;
    InventoryObjects head = new InventoryObjects();
    InventoryObjects arms = new InventoryObjects();
    InventoryObjects accessory = new InventoryObjects();
    InventoryObjects foot = new InventoryObjects();
    InventoryObjects weapon = new InventoryObjects();

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

    public InventoryObjects Head
    {
        get
        {
            return head;
        }

        set
        {
            head = value;
        }
    }
    public InventoryObjects Arms
    {
        get
        {
            return arms;
        }

        set
        {
            arms = value;
        }
    }
    public InventoryObjects Accessory
    {
        get
        {
            return accessory;
        }

        set
        {
            accessory = value;
        }
    }
    public InventoryObjects Foot
    {
        get
        {
            return foot;
        }

        set
        {
            foot = value;
        }
    }
    public InventoryObjects Weapon
    {
        get
        {
            return weapon;
        }

        set
        {
            weapon = value;
        }
    }

    [SerializeField]
    Sprite basicSprite;

    void Start () {
        player = GetComponent<PlayerPlatformerController>();
    }

    void Update () {
		
	}

    string equipItem(InventoryObjects itemToEquip)
    {
        switch (itemToEquip.getType())
        {
            case "head":
                Head = itemToEquip;
                headImage.sprite = itemToEquip.Sprite.sprite;
                upgradeDef();
                return ("head");
            case "arms":
                Arms = itemToEquip;
                armsImage.sprite = itemToEquip.Sprite.sprite;
                upgradeAttM();
                upgradeDef();
                return ("arms");
            case "accessory":
                Accessory = itemToEquip;
                accessoryImage.sprite = itemToEquip.Sprite.sprite;
                upgradeDef();
                return ("accessory");
            case "foot":
                Foot = itemToEquip;
                footImage.sprite = itemToEquip.Sprite.sprite;
                upgradeDef();
                return ("foot");
            case "weapon":
                Weapon = itemToEquip;
                weaponImage.sprite = itemToEquip.Sprite.sprite;
                upgradeAttD();
                return ("weapon");
            default:
                addItemToInv(itemToEquip);
                return ("error");
        }
    }

    void upgradeDef()
    {
        player.Defense = Head.DefenseBonus + Arms.DefenseBonus
            + Foot.DefenseBonus + Accessory.DefenseBonus;
    }

    void upgradeAttM()
    {
        player.AttackM = Arms.AttackBonus;
    }

    void upgradeAttD()
    {
        player.AttackD = Weapon.AttackBonus;
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
            Destroy(collider.gameObject);
        }
    }
}
