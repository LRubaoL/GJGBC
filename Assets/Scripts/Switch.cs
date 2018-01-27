using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
    bool switchPlayer;
    float timer;
    [SerializeField] GameObject m_PlayerOne;
    [SerializeField] GameObject m_PlayerTwo;

    private void FixedUpdate()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
        }
    }

    private void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyUp(KeyCode.T)&& timer <=0)
        {
            timer = 1f;
            SwitchTags();
            switchPlayer = !switchPlayer;
        }
    }
    void SwitchTags() {
            if (switchPlayer)
        {
            m_PlayerOne.tag = "Player";
            m_PlayerTwo.tag = "StaticPlayer";
        }
        else {
            m_PlayerOne.tag = "StaticPlayer";
            m_PlayerTwo.tag = "Player";
        }
    }

}
