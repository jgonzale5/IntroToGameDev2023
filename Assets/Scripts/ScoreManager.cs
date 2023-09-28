using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //The current score
    public int score = 0;
    //The text that will display the value of score
    public TextMeshProUGUI scoreDisplay;
    //The instance reference to this script
    public static ScoreManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        //We reset the score display to show the default value of the score
        scoreDisplay.text = score.ToString();

        //We set the instance to this script so it can be referenced from anywhere
        //in the game without having to look for it.
        Instance = this;
    }

    //The function that tells this script when to increase the score
    public void AddScore(int value)
    {
        //Add the value to the score
        score += value;
        //Change the scoredisplay to reflect the value of the score
        scoreDisplay.text = score.ToString();
    }
}
