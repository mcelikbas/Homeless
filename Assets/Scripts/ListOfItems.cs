using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfItems : MonoBehaviour
{
    private List<Item> items = new List<Item>();

    private void Awake ()
    {
        builListOfItems();
    }




    void builListOfItems ()
    {
        Items = new List<Item>()
        {
            new Item (1, "Berry","some food", 1),
            new Item (2, "Fiber","piece of sth", 2),
            new Item (3, "Stick","a piece of wood", 3),
            new Item (4, "Stone","hard rock", 4),
            new Item (5, "Water","drink this", 5)
        };
    }


    public List<Item> Items
    {
        get
        {
            return items;
        }

        set
        {
            items = value;
        }
    }

    public Item getItem (int id)
    {
        return Items.Find(item => item.Id == id);
    }

    public Item getItem (string itemName)
    {
        return Items.Find(item => item.ItemName == itemName);
    }



}
