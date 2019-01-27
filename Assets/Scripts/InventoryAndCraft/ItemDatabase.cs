using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    public List<Item> dataBaseItems = new List<Item>();

    public Item getItemById(int id)
    {
        Item itemToReturn = dataBaseItems[id];
        return itemToReturn;
    }
}
