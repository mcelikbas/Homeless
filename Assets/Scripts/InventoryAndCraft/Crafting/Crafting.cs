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
        print(itemToCraft.itemName);
    }

    bool canCraft(Item itemChecked)
    {
        return true;
    }

    void add(Item itemToAdd)
    {

    }

    void remove(Item itemToRemove)
    {

    }

}
