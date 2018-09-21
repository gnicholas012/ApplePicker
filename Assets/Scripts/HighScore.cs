using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int hiScore = 100;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScore = PlayerPrefs.GetInt("HighScore");
        }

    }
    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + hiScore;

        if (hiScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", hiScore);
        }
    }
}
