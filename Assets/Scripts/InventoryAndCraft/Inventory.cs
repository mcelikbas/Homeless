using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<GameObject> slots = new List<GameObject>();
    public ItemDatabase database;
	
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            Item item = database.getItemById(0);
           // showList();
        }
	}

    private void showList()
    {
        Item item = database.getItemById(0);
        Debug.Log("All occurence : \n");
        foreach (GameObject g in findAllOccurences(item))
        {
            Debug.Log(g.name);
        }
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
            //TODO UI Inventory full 

            return false;
        }
    }



    public void removeItem(Item itemToRemove, int amount)
    {
        int amountLeftToRemove = amount;
        for (int i = 0; i < slots.Count; i++)
        {
            Slot currentSlot = slots[i].GetComponent<Slot>();
            if (currentSlot.myItem == itemToRemove)
            {
                if (amountLeftToRemove <= currentSlot.myAmount)
                {
                    currentSlot.removeItem(amountLeftToRemove);
                    break;
                }
                else
                {
                    currentSlot.removeItem(currentSlot.myItem.maxStackAmount);

                    amountLeftToRemove -= currentSlot.myItem.maxStackAmount;
                }
            }
        }
    }

    public int countItem(Item itemToCount)
    {
        int counter = 0;
        for (int i = 0; i < slots.Count; i++)
        {
            Slot currentSlot = slots[i].GetComponent<Slot>();
            if (currentSlot.myItem == itemToCount)
            {
                counter += currentSlot.myAmount;
            }
        }
        return counter;
    }


    //public void removeItem(Item itemToRemove, int amount)
    //{
    //    List<GameObject> allItemsOccurences = findAllOccurences(itemToRemove);



    //    for (int i = 0; i < slots.Count; i++)
    //    {
    //        Slot currentSlot = slots[i].GetComponent<Slot>();
    //        if (currentSlot.myItem == itemToRemove)
    //        {
    //            currentSlot.removeItem(amount);
    //        }
    //    }
    //}

    public List<GameObject> findAllOccurences(Item itemToSearch)
    {
        List<GameObject> allItemsOccurences = new List<GameObject>();
        for (int i = 0; i < slots.Count; i++)
        {
            Slot currentSlot = slots[i].GetComponent<Slot>();
            if (currentSlot.myItem == itemToSearch)
            {
                allItemsOccurences.Add(slots[i]);
            }
        }
        return allItemsOccurences;
    }


    //---------------------------------------------------------Crafting helpers ------------------------------------------------------

    public bool hasItem(Item theItem, int amount)
    {
        return true;
    }

    public bool hasInInventory(string lookupItem, int amount)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].GetComponent<Slot>().myItem != null)
            {
                if (slots[i].GetComponent<Slot>().myItem.itemName == lookupItem && slots[i].GetComponent<Slot>().myAmount >=amount)
                {
                    return true;
                }
            }
        }
        return false;
    }



}
