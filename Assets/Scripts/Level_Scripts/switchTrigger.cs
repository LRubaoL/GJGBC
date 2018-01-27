using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        Destroy(gameObject);
    }
}
