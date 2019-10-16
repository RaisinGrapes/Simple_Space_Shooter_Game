using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosions : MonoBehaviour {

    float lifeTime = 0.8f;

    void Start()
    { 
        Destroy(gameObject, lifeTime);    
    }

}
