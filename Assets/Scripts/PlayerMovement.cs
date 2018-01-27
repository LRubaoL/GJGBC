using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : MonoBehaviour {
    
	[SerializeField] float rotateSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;
    [SerializeField] float doubleJumpForce;
    
    
    public bool grounded = false;
    bool jump = false;
    bool doubleJump = false;

    Rigidbody rbd;

    

	Camera playerCam;


    void Start() {
		playerCam = GameObject.FindGameObjectWithTag ("SceneCamera").GetComponent<Camera>();

        rbd = GetComponent<Rigidbody>();
    }

    void Update() {
		if (grounded) {
			jump = true;

		}	

		if (Input.GetButtonDown("Jump")&& grounded ||Input.GetKeyDown(KeyCode.W) && grounded){
			Jump();
            print ("Jump");
        }
		if (Input.GetButtonDown ("Jump") && !grounded && doubleJump) { //&& isKnockback == false) {
			DoubleJump();

        }
    }
	void OnCollisionStay(Collision c){
		if (c.gameObject.tag == "Ground") {
			grounded = true;
		} 
	}
	void OnCollisionExit(Collision c){
		if (c.gameObject.tag == "Ground" || c.gameObject.tag == "Player") {
		grounded = false;
		}
	}

	void FixedUpdate() {
            //Movement Translation
            float h = Input.GetAxis("Horizontal") * moveSpeed;
            h *= Time.deltaTime;
            transform.Translate(h, 0, 0, Space.World);
			
			Aim();        
    }

    void Aim() {
        if (!grounded) {

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 5;
            Vector3 objectPos = playerCam.WorldToScreenPoint(transform.position);
            mousePosition.x = mousePosition.x - objectPos.x;
            mousePosition.y = mousePosition.y - objectPos.y;
			float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
	        //transform.rotation = Quaternion.Euler(0, 0, angle);
			Quaternion _rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp (transform.rotation, _rotation, rotateSpeed*Time.deltaTime);
        }
    }

void Jump() {
		if (jump) {
			rbd.AddForce (new Vector2 (0, jumpForce));
			jump = false;
			doubleJump = true;
		}
	}
		void DoubleJump(){
        if (doubleJump) {
            rbd.AddForce(new Vector2(0, doubleJumpForce));
            doubleJump = false;
           
	}
    }

}
