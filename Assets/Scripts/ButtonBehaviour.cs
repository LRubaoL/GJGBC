﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour {

    public GameObject target;
    Animator AC;
    bool buttonTriggered;
    public string buttonName;


    void Start()
    {
        buttonTriggered = false;
        AC = target.GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "staticPlayer")
        {
            buttonTriggered = true;
            Debug.Log("button triggered");
        }
        if (other.gameObject.tag == "Player")
        {
            buttonTriggered = true;
            Debug.Log("button triggered");
        }
    }

    void Update()
    {
        if (buttonTriggered == true)
        {
            AC.SetBool(buttonName, true);
        }
    }
}
