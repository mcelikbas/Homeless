using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    private float speed = 5.0f;
    private float rotateSpeed;
    private float inputX;
    private float inputY;

    private Vector2 lastInput = new Vector2(0, 1);

    public Vector2 Xbounds;
    public Vector2 Ybounds;

    public Sprite spriteTop;
    public Sprite spriteRight;
    public Sprite spriteDown;
    private Sprite lastSprite;
    private SpriteRenderer spriteRenderer;


    private GameObject INV_MENU;
    private bool escMenu = false;
    private GameObject INV_MANAGER;
    private bool craftMenu = false;
    private ItemDatabase itemDatabase;
    private Inventory inventory;


    private Animator anim;


    private void Start ()
    {
        INV_MENU = GameObject.FindGameObjectWithTag("ESC_MENU");
        INV_MENU.SetActive(false);

        INV_MANAGER = GameObject.FindGameObjectWithTag("INV_MANAGER");
        INV_MANAGER.transform.GetChild(1).gameObject.SetActive(false);

        itemDatabase = GameObject.Find("INV_CRAFT").GetComponent<ItemDatabase>();
        inventory = GameObject.Find("INV_CRAFT").GetComponent<Inventory>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escMenu = !escMenu;
            if (escMenu)
            {
                INV_MENU.SetActive(true);
            }
            else
            {
                INV_MENU.SetActive(false);
            }
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
        //if (lastInput == Vector2.zero)
        //{
        //    anim.SetBool("isWalkingRight", false);
        //    anim.SetBool("isWalkingTop", false);
        //    anim.SetBool("isWalkingDown", false);
        //    spriteRenderer.sprite = lastSprite;
        //}


        // top
        if (lastInput.y == 1)
        {
            anim.SetBool("isWalkingTop", true);
            spriteRenderer.sprite = spriteTop;
        }
        if (lastInput.y == 0)
        {
            anim.SetBool("isWalkingTop", false);
            spriteRenderer.sprite = spriteTop;
        }
        
        // down
        if (lastInput.y == -1)
        {
            anim.SetBool("isWalkingDown", true);
            spriteRenderer.sprite = spriteDown;
        }
        if (lastInput.y == 0)
        {
            anim.SetBool("isWalkingDown", false);
            spriteRenderer.sprite = spriteDown;
        }

        // right
        if (lastInput.x == 1)
        {
            anim.SetBool("isWalkingRight", true);
            spriteRenderer.sprite = spriteRight;
            spriteRenderer.flipY = false;
            spriteRenderer.flipX = false;
        }
        if (lastInput.x == 0)
        {
            anim.SetBool("isWalkingRight", false);
            spriteRenderer.sprite = spriteRight;
            spriteRenderer.flipY = false;
            spriteRenderer.flipX = false;
        }

        // left
        if (lastInput.x == -1)
        {
            anim.SetBool("isWalkingRight", true);
            spriteRenderer.sprite = spriteRight;
            spriteRenderer.flipY = false;
            spriteRenderer.flipX = true;
        }
        if (lastInput.x == 0)
        {
            anim.SetBool("isWalkingRight", false);
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
