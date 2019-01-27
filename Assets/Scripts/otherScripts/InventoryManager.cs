using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    private List<Item> itemsInInventory = new List<Item>();

    const int QTY_TO_ADD = 3;


    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            showInventory();
        }
    }

    private void showInventory ()
    {
        Debug.Log("PLAYER INVENTORY IS: \n");
        foreach (Item item in itemsInInventory)
        {
            Debug.Log(item.ItemName + "(Id:" + item.Id + ") qty: " + item.Qty + " / " + item.MaxStackSize + "\n");
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Item item = other.GetComponent<ItemGatherable>().Item;
            addItem(item, QTY_TO_ADD);

            Debug.Log("Player got : " + item.ItemName + "(Id:" + item.Id + ")");
        }
    }



    public void addItem (Item itemToAdd, int qty)
    {
        List<Item> allItemsOccurences = itemsInInventory.FindAll(item => item.Id == itemToAdd.Id);
        int nbOfOccurences = allItemsOccurences.Count;
        int qtyLeftToAdd = qty;

        // if we have occurences not at full stacks, add items to it
        foreach (Item item in allItemsOccurences)
        {
            if (!item.isStackFull() && nbOfOccurences > 0)
            {
                if (qtyLeftToAdd + item.Qty < item.MaxStackSize)
                {
                    item.Qty += qtyLeftToAdd;
                    qtyLeftToAdd = 0;
                    break;
                }
                // put current stack at max stack
                else
                {
                    qtyLeftToAdd -= item.MaxStackSize - item.Qty;
                    item.Qty = item.MaxStackSize;
                }
            }
            nbOfOccurences--;
        }

        // all occurences were at full stack and we still have items to add, we create new stacks
        while (qtyLeftToAdd > 0)
        {
            Item newItem = new Item(itemToAdd.Id, itemToAdd.ItemName, itemToAdd.Description, itemToAdd.MaxStackSize);

            if (qtyLeftToAdd < newItem.MaxStackSize)
            {
                newItem.Qty = qtyLeftToAdd;
                qtyLeftToAdd = 0;
            }
            else
            {
                qtyLeftToAdd -= newItem.MaxStackSize - newItem.Qty;
                newItem.Qty = newItem.MaxStackSize;
            }
            ItemsInInventory.Add(newItem);
        }
    }


    public void removeItem (Item item, int qty)
    {
        ItemsInInventory.Remove(item);
    }

    public List<Item> ItemsInInventory
    {
        get
        {
            return itemsInInventory;
        }

        set
        {
            itemsInInventory = value;
        }
    }
}

