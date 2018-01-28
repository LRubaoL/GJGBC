using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour {

    public GameObject target;
    Animator AC;
    bool buttonTriggered;
    public string buttonName;
    Light lit;

    [SerializeField] GameObject text;

    void Start()
    {
        if (text == null)
        {
            return;
        }
        else
        {
            text.SetActive(false);
        }

        buttonTriggered = false;
        AC = target.GetComponent<Animator>();
        lit = gameObject.GetComponent<Light>();
    }

    void Update()
    {
        if (buttonTriggered == true)
        {
            AC.SetBool(buttonName, true);
            lit.intensity = 1;
        }
    }

    private void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag == "Player"&& text != null && buttonTriggered == false) {
            ShowText();
        } 

        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        { 
            buttonTriggered = true;
            Debug.Log("button triggered");
            if (text != null) {
                HideText();
            }
        }
    }
    private void OnTriggereExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && text != null && buttonTriggered == false)
        {
            HideText();
        }
    }



        void ShowText()
    {
        text.SetActive(true);
    }
    void HideText()
    {
        text.SetActive(false);
    }
}
