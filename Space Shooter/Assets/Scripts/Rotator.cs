using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public Rigidbody asteroid_rb = new Rigidbody();

    void Start()
    {
        asteroid_rb.angularVelocity = new Vector3(Random.value, Random.value, Random.value) * 2.0f;
        
    }

}
