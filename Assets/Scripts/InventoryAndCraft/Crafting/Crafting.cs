using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour {

    public ItemDatabase database;
    public Inventory inventory;

    public GameObject craftingPanel;
    public GameObject craftingSlot;

    void Start()
    {
        GenerateSlots();
    }

    void GenerateSlots()
    {
        for(int i= 0; i < database.dataBaseItems.Count; i++)
        {
            Item currentItem = database.dataBaseItems[i];
            if (currentItem.isCraftable)
            {
                GameObject go = Instantiate(craftingSlot,craftingPanel.transform.position, Quaternion.identity);
                go.transform.SetParent(craftingPanel.transform);
                go.GetComponent<CraftingSlot>().myItem = currentItem;
            }
        }
    }

    public void craftItem(Item itemToCraft)
    {
        if (itemToCraft.isCraftable)
        {
            if (canCraft(itemToCraft))
            {
                add(itemToCraft);
            }
            else
            {
               //TODO UI can't craf item no enough ressources
            }
        }
        else
        {
            return ;
        }
    }

    bool canCraft(Item itemChecked)
    {
        for(int i = 0; i < itemChecked.craftItems.Count; i++)
        {
            Item currentItem = itemChecked.craftItems[i];
            int currentAmount = itemChecked.craftAmount[i];

            if (!inventory.hasInInventory(currentItem.itemName, currentAmount))
            {
                return false;
            }
            
        }
        return true;
    }

    void add(Item itemToAdd)
    {
        //TODO UI craft item added to inventory
        inventory.addItem(itemToAdd, itemToAdd.craftHowMany);
        remove(itemToAdd);
    }

    void remove(Item itemToRemove)
    {
        for (int i = 0; i < itemToRemove.craftItems.Count; i++)
        {
            Item currentItem = itemToRemove.craftItems[i];
            int currentAmount = itemToRemove.craftAmount[i];
            inventory.removeItem(currentItem, currentAmount);
        }
    }

}
