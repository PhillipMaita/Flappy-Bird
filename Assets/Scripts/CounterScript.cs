using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//use UI elements, like text, in unity
using UnityEngine.UI;

public class CounterScript : MonoBehaviour
{
    //declare a text UI element to be assigned in Unity
    public Text Flaps;
    //create a variable that keeps track of the actual score 
    private int flaps;
    private int highScore;

    void Start()
    {
        flaps = 0;
        SetCountText();
        PlayerPrefs.SetInt("Score", 0);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0))
        {
            flaps = flaps + 1;
            SetCountText();

            PlayerPrefs.SetInt("Score", flaps);
            highScore = PlayerPrefs.GetInt("High Score");

            if (flaps > highScore)
            {
                PlayerPrefs.SetInt("High Score", flaps);
            }

        }
    }


    //display the score dynamically as it changes
    void SetCountText()
    {
        //change the value of the UI Text object 
        Flaps.text = "FLAPS: " + flaps.ToString();
    }
}