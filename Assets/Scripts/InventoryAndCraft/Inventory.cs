﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<GameObject> slots = new List<GameObject>();
	
	
	void Update () {
		
	}

    public bool addItem(Item itemToAdd, int amount)
    {
        Slot emptySlot = null;
        for (int i = 0; i < slots.Count; i++)
        {
            Slot currentSlot = slots[i].GetComponent<Slot>();
            if (currentSlot.myItem == itemToAdd && itemToAdd.isStackable && currentSlot.myAmount + amount <= itemToAdd.maxStackAmount )
            {
                currentSlot.addItem(itemToAdd,amount);
                return true;
            }
            else if (currentSlot.myItem == null && emptySlot == null)
            {
                emptySlot = currentSlot;
            }
        }

        if (emptySlot != null)
        {
            emptySlot.addItem(itemToAdd, amount);
            return true;
        }
        else
        {
            print("inventory is full");
            return false;
        }
    }



    public void removeItem(Item itemToRemove, int amount)
    {
        
    }


    //---------------------------------------------------------Crafting helpers ------------------------------------------------------

    public bool hasItem(Item theItem, int amount)
    {
        return true;
    }


}