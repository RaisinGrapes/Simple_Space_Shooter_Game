using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] asteroids;
    public int stuffCount = 10;
    float spawnWait = 0.5f;
    float startWait = 1;
    float waveWait = 2;

    public TextMesh restart_txt;
    public TextMesh game_over_txt;

    bool gameOver;
    bool restart;
    // Use this for initialization
    void Start () {
        gameOver = false;
        restart = false;
        restart_txt.text = "";
        game_over_txt.text = "";
        StartCoroutine (SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }    
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true){
            for (int i = 0; i != stuffCount; i += 1) {

                GameObject asteroid = asteroids[Random.Range(0, asteroids.Length)];  // selects one of the 3 asteroids randomly
                // spawn range within the horizontal boundary and beyond the top boundary
                Vector3 spawnPosition = new Vector3(Random.Range(-6, 6), 0.0f, 14.25f);
                // 'identity' means no rotation essetially
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(asteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restart_txt.text = "Press 'R' to play again";
                restart = true;
                break;
            }
        }
    }

    public void GameOver()
    {
        game_over_txt.text = "Game Over";
        gameOver = true;
    }

}
