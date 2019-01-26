using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float speed = 5.0f;
    private float rotateSpeed ;
    private float inputX;
    private float inputY;

    private Vector2 lastInput = new Vector2(0,1);

    public Sprite spriteTop;
    public Sprite spriteRight;
    private SpriteRenderer spriteRenderer;

    private void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update ()
    {
        move();
        updateSprite();
        //mouseLook();
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
            spriteRenderer.flipX = false;
        }
        else if (lastInput.x == -1)
        {
            spriteRenderer.sprite = spriteRight;
            spriteRenderer.flipX = true;
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
