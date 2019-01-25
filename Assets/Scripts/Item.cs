using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    private string itemName;
    private string description;

    public Item (string itemName, string description)
    {
        this.ItemName = itemName;
        this.Description = description;
    }

    public string ItemName
    {
        get
        {
            return itemName;
        }

        set
        {
            itemName = value;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }

        set
        {
            description = value;
        }
    }
}
