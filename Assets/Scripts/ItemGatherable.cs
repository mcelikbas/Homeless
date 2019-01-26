using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGatherable : MonoBehaviour {

    public int id;
    private Item item;

    private ListOfItems listOfItems;

	void Start () {
        listOfItems = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ListOfItems>();
        item = listOfItems.getItem(id);
	}
	

	void Update () {
        
	}



    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(item.ItemName + "      " + item.ItemName);
            Destroy(this.gameObject);
        }
    }

}
