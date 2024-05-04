using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private Text scoreText;
    private static int lastScore = 0;

    void Start()
    {
        StartCoroutine(Score());
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    IEnumerator Score()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.7f);
            score++;
            lastScore = score;
        }
    }
}
