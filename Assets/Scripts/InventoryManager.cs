using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    private List<Item> itemsInInventory = new List<Item>();

    const int QTY_TO_ADD = 2;


    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Player currently have : ");
            foreach (Item item in itemsInInventory)
            {
                Debug.Log(item.ItemName + "(Id:" + item.Id + ") qty: " + item.Qty + " / " + item.MaxStackSize + "\n");
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Item item = other.GetComponent<ItemGatherable>().Item;
            Debug.Log("Player got : " + item.ItemName + "(Id:" + item.Id + ")");

            addItem(item, QTY_TO_ADD);
        }
    }



    public void addItem (Item itemToSearch, int qty)
    {
        int qtyToObtain = qty;
        if (itemsInInventory.Contains(itemToSearch))
        {
            List<Item> allItemsOccurences = itemsInInventory.FindAll(item => item.Id == itemToSearch.Id);
            int nbOfOccurences = allItemsOccurences.Count;
            foreach (Item item in allItemsOccurences)
            {
                if ((item.Qty + qtyToObtain ) < item.MaxStackSize)
                {
                    itemToSearch.Qty += qtyToObtain;
                    break;
                }
                else
                {
                    if (item.Qty < item.MaxStackSize)
                    {
                        int qtyAvailableToDistribute = item.MaxStackSize - item.Qty;
                        qtyToObtain -= qtyAvailableToDistribute;
                        item.Qty += qtyAvailableToDistribute;
                        nbOfOccurences--;
                    }
                    else
                    {
                        if (nbOfOccurences == 1 && item.Qty == item.MaxStackSize )
                        {
                            Item newItem = new Item(itemToSearch.Id, itemToSearch.ItemName, itemToSearch.Description, itemToSearch.MaxStackSize);
                            newItem.Qty = qtyToObtain;
                            ItemsInInventory.Add(newItem);
                            break;
                        }
                    }
                }
                nbOfOccurences--;
            }
        }
        else
        {

            // TODO manage stack size correctly

            itemToSearch.Qty = qtyToObtain;
            ItemsInInventory.Add(itemToSearch);
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
