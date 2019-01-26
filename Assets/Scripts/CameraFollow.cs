using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    //public float smoothSpeed = 1f;
    private Vector3 offset = new Vector3(0f,0f,-1f);



	void LateUpdate () {

        Vector3 desiredPosition = target.position + offset;
        transform.position = desiredPosition;

        
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;
        // transform.LookAt(target);

	}
}
