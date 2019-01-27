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

    public Vector2 Xbounds;
    public Vector2 Ybounds;

    public Sprite spriteTop;
    public Sprite spriteRight;
    public Sprite spriteDown;
    private SpriteRenderer spriteRenderer;


    private GameObject INV_MANAGER;
    private bool craftMenu = false;
    private ItemDatabase itemDatabase;
    private Inventory inventory;


    private void Start ()
    {
        INV_MANAGER = GameObject.FindGameObjectWithTag("INV_MANAGER");
        INV_MANAGER.transform.GetChild(1).gameObject.SetActive(false);

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
            if (craftMenu)
            {
                INV_MANAGER.transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                INV_MANAGER.transform.GetChild(1).gameObject.SetActive(false);
            }
            craftMenu = !craftMenu;
        }
    }


    private void move ()
    {
        inputX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        inputY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        lastInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        checkBoundary();

        transform.Translate(inputX, inputY, 0);
    }


    private void checkBoundary ()
    {
        if (transform.position.x > Xbounds.y)
        {
            transform.position = new Vector3(Xbounds.y, transform.position.y, 0);
        }
        if (transform.position.x < Xbounds.x)
        {
            transform.position = new Vector3(Xbounds.x, transform.position.y, 0);
        }
        if (transform.position.y > Ybounds.y)
        {
            transform.position = new Vector3(transform.position.x, Ybounds.y, 0);
        }
        if (transform.position.y < Ybounds.x)
        {
            transform.position = new Vector3(transform.position.x, Ybounds.x, 0);
        }
    }


    private void updateSprite ()
    {
        if(lastInput.y == 1)
        {
            spriteRenderer.sprite = spriteTop;
        }
        else if (lastInput.y == -1)
        {
            spriteRenderer.sprite = spriteDown;
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
