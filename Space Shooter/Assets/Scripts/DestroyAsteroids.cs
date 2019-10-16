using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroids : MonoBehaviour
{


    public GameObject explosion;
    public GameObject player_explosion;
    private GameController gc;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gc = gameControllerObject.GetComponent<GameController>();  // gets the GameController script
        }

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Boundary")
        {
            Destroy(gameObject);
            return;
        }
        else if (other.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(player_explosion, other.transform.position, other.transform.rotation);
            gc.GameOver();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else
        {
            Instantiate(explosion, transform.position, transform.rotation);
            ScoreHolder.UpdateScore(10);
            Destroy(gameObject);
            Destroy(other.gameObject);

        }
    }
}
