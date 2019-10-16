using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody plane_rb = new Rigidbody();
    float tilt = 4.5f;
    float speed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    public GameObject bolt;
    public Transform bolt_spawn;
    float next_fire = 0.0f;
    float fire_rate = 0.25f;

    void Update()
    {
        // shooting
        if (Input.GetButton("Jump") && Time.time > next_fire) {
            next_fire = Time.time + fire_rate;
            Instantiate(bolt, bolt_spawn.position, bolt_spawn.rotation);  // accumulation of bolt GameObject

        }
    }

    void FixedUpdate () {

        // motion if the plane
        float h_motion = Input.GetAxis("Horizontal");
        float v_motion = Input.GetAxis("Vertical");

        // boundaries
        float l_boundary = -5.5f;
        float r_boundary = 5.5f;
        float t_boundary = 4.0f;
        float b_boundary = -2.86f;

        Vector3 motion = new Vector3(h_motion, 0.0f, v_motion);
        plane_rb.velocity = motion * speed;

        // keeping the plane within the boundaries
        plane_rb.position = new Vector3(Mathf.Clamp(plane_rb.position.x, l_boundary, r_boundary),
            0.0f, Mathf.Clamp(plane_rb.position.z, b_boundary, t_boundary));

        // tilt motion
        plane_rb.rotation = Quaternion.Euler(0.0f, 0.0f, plane_rb.velocity.x * -tilt);
    }
}
