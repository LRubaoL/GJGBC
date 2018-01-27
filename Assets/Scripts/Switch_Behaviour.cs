using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Behaviour : MonoBehaviour
{
    [SerializeField] public bool switchOne;
    [SerializeField] GameObject switchTwo;



    private void OnTriggerStay(Collider c)
    {
        c.GetComponent<ComponentsToDisable>();
        
    }
}
