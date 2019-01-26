using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    private List<Item> itemsInInventory = new List<Item>();

    const int QTY_TO_ADD = 4;


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


            Debug.Log("testInventory 2 : " + itemsInInventory.Contains(item));
 
            //Debug.Log("Player got : " + item.ItemName + "(Id:" + item.Id + ")");
        }
    }



    public void addItem (Item itemToAdd, int qty)
    {
        //int qtyToObtain = qty;

        Debug.Log("testInventory 1 : " + itemsInInventory.Contains(itemToAdd));

        if (ItemsInInventory.Contains(itemToAdd))
        {
            Debug.Log("Item IS present");

            List<Item> allItemsOccurences = itemsInInventory.FindAll(item => item.Id == itemToAdd.Id);
            int nbOfOccurences = allItemsOccurences.Count;
            foreach (Item item in allItemsOccurences)
            {
                Debug.Log("herehere");
                if (!item.isStackFull() && nbOfOccurences > 0)
                {
                    createNewStacksOfItemAndAddQty(item, qty);
                    Debug.Log("HERE");
                }
                nbOfOccurences--;
                

                //if ((item.Qty + qtyToObtain) < item.MaxStackSize)
                //{
                //    itemToSearch.Qty += qtyToObtain;
                //    break;
                //}
                //// items we wanna add are greater than the stack size allowed for that item
                //else
                //{
                //    if (item.Qty < item.MaxStackSize)
                //    {
                //        int qtyAvailableToDistribute = item.MaxStackSize - item.Qty;
                //        qtyToObtain -= qtyAvailableToDistribute;
                //        item.Qty += qtyAvailableToDistribute;
                //        nbOfOccurences--;

                //        if (nbOfOccurences < 1 && qtyToObtain > 0)
                //        {
                //            for (int i = 0; i < Mathf.Ceil((qtyToObtain / item.MaxStackSize)); i++)
                //            {
                //                Item newItem = new Item(itemToSearch.Id, itemToSearch.ItemName, itemToSearch.Description, itemToSearch.MaxStackSize);
                //                qtyAvailableToDistribute = newItem.MaxStackSize - newItem.Qty;
                //                qtyToObtain -= qtyAvailableToDistribute;
                //                newItem.Qty = qtyAvailableToDistribute;
                //            }
                //            break;
                //        }

                //        //Debug.Log("stack was cerated");
                //    }
                //    else
                //    {
                //        if (nbOfOccurences == 1 && item.isStackFull())
                //        {
                //            Item newItem = new Item(itemToSearch.Id, itemToSearch.ItemName, itemToSearch.Description, itemToSearch.MaxStackSize);
                //            newItem.Qty = qtyToObtain;
                //            ItemsInInventory.Add(newItem);
                //            break;
                //        }
                //    }
                //}
                //nbOfOccurences--;
            }
        }
        else
        {
            Debug.Log("Item IS NOT present");

            createNewStacksOfItemAndAddQty(itemToAdd, qty);
        }
    }


    // add "qty" items to inventory, create new stacks of item if qty>maxStackSize of item
    private void createNewStacksOfItemAndAddQty (Item item, int qty)
    {
        int qtyLeftToDistribute = qty;
        while (qtyLeftToDistribute > 0)
        {
            Item newItem = new Item(item.Id, item.ItemName, item.Description, item.MaxStackSize);
            if (qtyLeftToDistribute < newItem.MaxStackSize)
            {
                newItem.Qty = qtyLeftToDistribute;
                ItemsInInventory.Add(newItem);
                qtyLeftToDistribute = 0;
            }
            else
            {
                newItem.Qty = newItem.MaxStackSize;
                ItemsInInventory.Add(newItem);
                qtyLeftToDistribute -= newItem.MaxStackSize;
            }
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
