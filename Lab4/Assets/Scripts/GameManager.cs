using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private ScoreManager scoreManager;
    private int score = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = scoreManager.score;
        scoreText.text = "Score: " + score.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
