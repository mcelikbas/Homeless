using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGatherable : MonoBehaviour {

    public int id;
    private Item item;

    private ListOfItems listOfItems;



    void Start () {
        listOfItems = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ListOfItems>();
        Item = listOfItems.getItem(id);
    }
	

	void Update () {
        
	}



    public Item Item
    {
        get
        {
            return item;
        }

        set
        {
            item = value;
        }
    }
}
