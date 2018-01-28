using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBehaviour : MonoBehaviour
{

    void FixedUpdate()
    {
        if (gameObject.tag == "Player")
        {
            GetComponent<PlayerMovement>().isSphere = true;
        }


    }
}
