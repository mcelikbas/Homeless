using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfItems : MonoBehaviour
{
    public List<Item> items = new List<Item>();


    private void Awake ()
    {
        builListOfItems();
    }




    void builListOfItems ()
    {
        items = new List<Item>()
        {
            new Item (1, "Berry","some food"),
            new Item (2, "Fiber","piece of sth"),
            new Item (3, "Stick","a piece of wood"),
            new Item (4, "Stone","hard rock"),
            new Item (5, "Water","drink this")
        };
    }


    public Item getItem (int id)
    {
        return items.Find(item => item.Id == id);
    }








    //public static Item ITEM_GATHERABLE_BERRY = new Item (1, "Berry","some food");

    //public static Item ITEM_GATHERABLE_FIBER = new Item (2, "Fiber","piece of sth");

    //public static Item ITEM_GATHERABLE_STICK = new Item (3, "Stick","a piece of wood");

    //public static Item ITEM_GATHERABLE_STONE = new Item (4, "Stone","hard rock");

    //public static Item ITEM_GATHERABLE_WATER = new Item (5, "Water","drink this");





}
