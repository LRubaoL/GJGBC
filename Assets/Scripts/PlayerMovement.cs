using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : MonoBehaviour {
    
	[SerializeField] float rotateSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;
    [SerializeField] public float doubleJumpForce;

    public bool isCube;
    
    public bool grounded = false;
    public bool jump = false;

    public bool doubleJump = false;
    

    public Rigidbody rbd;

    

	Camera playerCam;


    void Start() {
        if (playerCam == null)
        {
            playerCam = GameObject.FindGameObjectWithTag("SceneCamera").GetComponent<Camera>();
        }
        else {
            return;
        }
        rbd = GetComponent<Rigidbody>();
    }

    void Update() {
      
        if (grounded && gameObject.tag == "Player") {
			jump = true;

		}	

		if (Input.GetButtonDown("Jump")&& grounded ||Input.GetKeyDown(KeyCode.W) && grounded && gameObject.tag == "Player")
        {
			Jump();
            print ("Jump");
        }
		if (Input.GetButtonDown ("Jump") && !grounded && isCube && doubleJump && gameObject.tag == "Player") { 
			GetComponent<CubeBehaviour>().DoubleJump();

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
        if (gameObject.tag == "Player")
        {
            float h = Input.GetAxis("Horizontal") * moveSpeed;
            h *= Time.deltaTime;
            transform.Translate(h, 0, 0, Space.World);
        }

        //Aim();        
    }

    /*void Aim() {
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
    }*/

void Jump() {
		if (jump && gameObject.tag == "Player") {
			rbd.AddForce (new Vector2 (0, jumpForce));
			jump = false;
			doubleJump = true;
		}
	}


}
