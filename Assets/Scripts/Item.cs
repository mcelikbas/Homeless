using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

    private int id;
    private string itemName;
    private string description;
    private int qty;
    private int maxStackSize;

    public Item (int id, string itemName, string description, int maxStackSize)
    {
        this.Id = id;
        this.ItemName = itemName;
        this.Description = description;
        this.Qty = 0;
        this.MaxStackSize = maxStackSize;
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

    public int Qty
    {
        get
        {
            return qty;
        }

        set
        {
            qty = value;
        }
    }

    public int MaxStackSize
    {
        get
        {
            return maxStackSize;
        }

        set
        {
            maxStackSize = value;
        }
    }
}
