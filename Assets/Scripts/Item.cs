using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    private int id;
    private string itemName;
    private string description;

    public Item (int id, string itemName, string description)
    {
        this.Id = id;
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

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }
}
