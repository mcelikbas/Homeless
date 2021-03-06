﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Slot : MonoBehaviour, IPointerClickHandler
{

    Image myImage;
    Text myText;

    public Item myItem;
    public int myAmount;

    void Start()
    {
        myImage = transform.GetChild(0).GetComponent<Image>();
        myText = transform.GetChild(1).GetComponent<Text>();
        showUI();
    }

    

    public void addItem(Item itemToAdd, int amount)
    {
        if (itemToAdd == myItem)
        {
            myAmount += amount;
        }
        else
        {
            myItem = itemToAdd;
            myAmount = amount;
        }
        showUI();
    }

    public void removeItem(int amount)
    {
        if (myItem != null)
        {
            myAmount -= amount;
            if (myAmount <= 0)
            {
                myItem = null;
            }
        }
        showUI();
    }

    void showUI()
    {
        if (myItem != null)
        {
            myImage.enabled = true;
            myText.enabled = true;
            myImage.sprite = myItem.itemIcon;
            myText.text = myAmount.ToString();
        }
        else
        {
            myImage.enabled = false;
            myText.enabled = false;
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        removeItem(myAmount);
    }
}
