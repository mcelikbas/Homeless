using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float speed = 5.0f;
    private float inputX;
    private float inputY;


	void Update () {

        inputX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        inputY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(inputX, inputY, 0);
    }
}
