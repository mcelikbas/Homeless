using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quickadd : MonoBehaviour {

    public ItemDatabase database;
    public Inventory inventory;

	void Update () {

        
        if (Input.GetButtonDown("Fire1"))
        {
           // inventory.addItem(database.getItemById(0), 1);
        }

    }
}
