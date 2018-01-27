using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : PlayerMovement {

    void FixedUpdate()
    {
        if (gameObject.tag == "Player")
        {
            GetComponent<PlayerMovement>().isCube = true;
        }
    }
    public void DoubleJump()
    {
        if (doubleJump && gameObject.tag == "Player")
        {
            rbd.AddForce(new Vector2(0, doubleJumpForce));
            doubleJump = false;

        }
    }
}
