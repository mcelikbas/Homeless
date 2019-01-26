using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    public List<ScItem> dataBaseItems = new List<ScItem>();

    public ScItem getItemById(int id)
    {
        ScItem itemToReturn = dataBaseItems[id];
        Debug.Log("getitemid : " + itemToReturn);
        return itemToReturn;
    }
}
