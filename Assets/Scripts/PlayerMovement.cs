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
	void OnTriggerStay(Collider c){
		if (c.gameObject.tag == "Ground") {
			grounded = true;
		} 
	}
	void OnTriggerExit(Collider c){
		if (c.gameObject.tag == "Ground" || c.gameObject.tag == "Player") {
		grounded = false;
		}
	}

	void FixedUpdate() {

        if (!grounded)
        {
            float i;
            i =+ Time.deltaTime*450;
            rbd.AddForce(Vector3.down * i, ForceMode.Force);
        }
        if (gameObject.tag == "Player")
        {
            float h = Input.GetAxis("Horizontal") * moveSpeed;
            h *= Time.deltaTime;
            transform.Translate(h, 0, 0, Space.World);
        }

          
    }


void Jump() {
		if (jump && gameObject.tag == "Player") {
			rbd.AddForce (new Vector2 (0, jumpForce));
			jump = false;
			doubleJump = true;
		}
	}


}
