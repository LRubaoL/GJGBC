using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
    bool switchPlayer;
    float timer;
    [SerializeField] GameObject m_PlayerOne;
    [SerializeField] GameObject m_PlayerTwo;

    [SerializeField] GameObject text;

    private void Awake()
    {
        if (text == null)
        {
            return;
        }
        else
        {
            text.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            ShowText();
        }
        if (other.gameObject.tag == "Player" && Input.GetKeyUp(KeyCode.Tab) && timer <= 0)
        {
            timer = 1f;
            SwitchTags();
            switchPlayer = !switchPlayer;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HideText();
        }
    
    }
    void SwitchTags()
    {

        if (switchPlayer)
        {
            m_PlayerOne.tag = "Player";
            m_PlayerTwo.tag = "StaticPlayer";
        }
        else
        {
            m_PlayerOne.tag = "StaticPlayer";
            m_PlayerTwo.tag = "Player";
        }
        GameObject.FindGameObjectWithTag("SceneCamera").GetComponent<Camera_Behaviour>().PlayerChange();
    }
    void ShowText() {
        text.SetActive(true);
    }
    void HideText()
    {
        text.SetActive(false);
    }
}
