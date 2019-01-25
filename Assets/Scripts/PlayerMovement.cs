using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float speed = 5.0f;
    private float rotateSpeed ;
    private float inputX;
    private float inputY;




	void Update ()
    {
        move();
        //mouseLook();
    }


    private void move ()
    {
        inputX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        inputY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(inputX, inputY, 0);
    }

    private void mouseLook ()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = direction;
    }
}
