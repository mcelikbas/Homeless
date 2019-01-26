using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<GameObject> slots = new List<GameObject>();
	
	
	void Update () {
		
	}

    public bool addItem(ScItem itemToAdd, int amount)
    {
        Slot emptySlot = null;
        for (int i = 0; i < slots.Count; i++)
        {
            Slot currentSlot = slots[i].GetComponent<Slot>();
            if (currentSlot.myItem == itemToAdd)
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
            return false;
        }
    }



    public void removeItem(ScItem itemToRemove, int amount)
    {
        
    }


    //---------------------------------------------------------Crafting helpers ------------------------------------------------------

    public bool hasItem(ScItem theItem, int amount)
    {
        return true;
    }


}
