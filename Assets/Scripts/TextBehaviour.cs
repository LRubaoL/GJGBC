using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBehaviour : MonoBehaviour {
    Transform target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("SceneCamera").transform;
    }
    private void FixedUpdate()
    {
        transform.LookAt(target);
    }
}
