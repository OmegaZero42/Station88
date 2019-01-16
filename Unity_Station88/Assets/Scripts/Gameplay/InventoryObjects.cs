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
    SpriteRenderer sprite;

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

    public SpriteRenderer Sprite
    {
        get
        {
            return sprite;
        }

        set
        {
            sprite = value;
        }
    }

    void Start () {
        if (!"head arms accessory foot weapon".Contains(itemType))
        {
            Debug.LogError("Item creation failed");
        }
        Sprite = GetComponent<SpriteRenderer>();
	}

    public string getType()
    {
        return(itemType);
    }

    public bool exists()
    {
        return (true);
    }
}
