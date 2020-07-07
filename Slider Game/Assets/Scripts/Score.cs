using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score;
    private Text scoreText;
    public Text highScore;

    private void Start()
    {
        scoreText = GetComponent<Text>();

        score = 0;
        scoreText.text = ((int)score).ToString();

        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        score += Time.deltaTime * 50;
        scoreText.text = ((int)score).ToString();
    }

    public void RecordHighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
            highScore.text = ((int)score).ToString();
        }
    }

}
