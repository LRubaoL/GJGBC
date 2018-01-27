using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Camera_Behaviour : MonoBehaviour {

	[SerializeField] GameObject player;

	float smoothSpeed = 0.3f;
	public Vector3 offset;
    Vector3 velocity;

	void Awake(){
        if (player == null) {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        

    }
	// Update is called once per frame
	void FixedUpdate () {
        
        Vector3 desiredPos = new Vector3(offset.x + player.transform.position.x, offset.y + player.transform.position.y, offset.z);
        Vector3 smoothedPos = Vector3.SmoothDamp (transform.position, desiredPos, ref velocity ,smoothSpeed);
        transform.position = smoothedPos;


    }
    public void PlayerChange() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
