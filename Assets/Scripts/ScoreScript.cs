using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text score;
    public Text highScore;

    // Use this for initialization
    void Start()
    {
        score.text = "FLAPS: " + PlayerPrefs.GetInt("Score").ToString();
        highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("High Score").ToString();
    }
}