using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slot : MonoBehaviour {

    Image myImage;
    Text myText;

    public ScItem myItem;
    public int myAmount;

    void Start()
    {
        myImage = transform.GetChild(0).GetComponent<Image>();
        myText = transform.GetChild(1).GetComponent<Text>();
        showUI();
    }

    

    public void addItem(ScItem itemToAdd, int amount)
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

}
