using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour {

    public Sprite tree_test_0;





    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = tree_test_0;
        }

    }
}
