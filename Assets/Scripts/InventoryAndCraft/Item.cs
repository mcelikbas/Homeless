using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject {

    public string itemName;
    public Sprite itemIcon;

    //stackable stuff
    public bool isStackable;
    public int maxStackAmount;

    //crafting stuff
    public bool isCraftable;
    public List<Item> craftItems = new List<Item>();
    public List<int> craftAmount = new List<int>();
    public int craftHowMany;

    //public int minLevelToCraft; (prochaine feature * progression)
}

