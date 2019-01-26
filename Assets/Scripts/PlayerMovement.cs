using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    private float speed = 5.0f;
    private float rotateSpeed ;
    private float inputX;
    private float inputY;

    private Vector2 lastInput = new Vector2(0,1);

    public Sprite spriteTop;
    public Sprite spriteRight;
    private SpriteRenderer spriteRenderer;


    private GameObject INV_MANAGER;
    private bool inventoryIsHidden = true;
    private ItemDatabase itemDatabase;
    private Inventory inventory;


    private void Start ()
    {
        INV_MANAGER = GameObject.FindGameObjectWithTag("INV_MANAGER");
        INV_MANAGER.transform.GetChild(0).gameObject.SetActive(false);

        itemDatabase = GameObject.Find("INV_CRAFT").GetComponent<ItemDatabase>();
        inventory = GameObject.Find("INV_CRAFT").GetComponent<Inventory>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update ()
    {
        move();
        updateSprite();
        //mouseLook();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryIsHidden)
            {
                INV_MANAGER.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                INV_MANAGER.transform.GetChild(0).gameObject.SetActive(false);
            }
            inventoryIsHidden = !inventoryIsHidden;
        }
    }


    private void move ()
    {
        inputX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        inputY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        lastInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        transform.Translate(inputX, inputY, 0);
    }

    private void updateSprite ()
    {
        if(lastInput.y == 1)
        {
            spriteRenderer.sprite = spriteTop;
            spriteRenderer.flipY = false;
        }
        else if (lastInput.y == -1)
        {
            spriteRenderer.sprite = spriteTop;
            spriteRenderer.flipY = true;
        }
        
        if (lastInput.x == 1)
        {
            spriteRenderer.sprite = spriteRight;
            spriteRenderer.flipY = false;
            spriteRenderer.flipX = false;
        }
        else if (lastInput.x == -1)
        {
            spriteRenderer.sprite = spriteRight;
            spriteRenderer.flipY = false;
            spriteRenderer.flipX = true;
        }

    }

    private void pickUpItem (int itemId, int qty)
    {
        inventory.addItem(itemDatabase.getItemById(itemId), qty);
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            ItemToPick itemToPick = other.GetComponent<ItemToPick>();

            Debug.Log("player hit" + other.name);
            pickUpItem(itemToPick.id, itemToPick.qty);
        }
    }



    private void mouseLook ()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = direction;
    }




}
