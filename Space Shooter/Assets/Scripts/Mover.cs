using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public Rigidbody bolt_rb = new Rigidbody();
    public float speed;
    void Start()
    {
        bolt_rb.velocity = transform.forward * speed;
    }
}
