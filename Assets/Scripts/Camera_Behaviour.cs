using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Camera_Behaviour : MonoBehaviour {

	GameObject player;

	float smoothSpeed = 0.4f;
	public Vector3 offset;
    Vector3 velocity;

	void Awake(){
        
        

    }
	// Update is called once per frame
	void FixedUpdate () {
        player = GameObject.FindGameObjectWithTag("Player");


        

        Vector3 desiredPos = new Vector3(offset.x + player.transform.position.x, offset.y + player.transform.position.y, offset.z);
        Vector3 smoothedPos = Vector3.SmoothDamp (transform.position, desiredPos, ref velocity ,smoothSpeed);
        transform.position = smoothedPos;


    }
}
