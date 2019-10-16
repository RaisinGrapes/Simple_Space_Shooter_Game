using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour {

    public TextMesh scoreHolder;
    static int score;
	// Use this for initialization
	void Start () {
        score = 0;
        scoreHolder.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
        scoreHolder.text = "Score: " + score;
    }

    public static void UpdateScore(int increment)
    {
        score += increment;
    }
}
