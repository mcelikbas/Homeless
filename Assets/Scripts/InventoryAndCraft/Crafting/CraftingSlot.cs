using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CraftingSlot : MonoBehaviour, IPointerClickHandler {

    Crafting craftingScript;

    public Item myItem;
    Image myIcon;

    void Start()
    {
        if (myItem == null)
        {
            Destroy(gameObject);
        }
       
        craftingScript = GameObject.FindObjectOfType<Crafting>();
        myIcon = GetComponent<Image>();
        myIcon.sprite = myItem.itemIcon;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        craftingScript.craftItem(myItem);
    }

    // public void OnPointerClick(PointerEventData eventData)
    // { 
    //     craftingScript.craftItem(myItem);
    // }


}
