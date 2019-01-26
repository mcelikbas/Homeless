using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScItem : ScriptableObject {

    public string itemName;
    public Sprite itemIcon;

    public bool isStackable;
    public int maxStackAmount;

    public bool isCraftable;
    public List<ScItem> craftItems = new List<ScItem>();
    public List<int> craftAmount = new List<int>();
}
