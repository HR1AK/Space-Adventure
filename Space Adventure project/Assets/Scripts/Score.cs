using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instatiate;
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI hightScore;
    private int score;
    private int record;

    private void Start()
    {
        StartCoroutine(ITimer());
    }

   IEnumerator ITimer()
   {
        while(true)
        {
            UpdateScore();

            yield return new WaitForSeconds(1);
        }
   }

    private void Awake()
    {
        record = PlayerPrefs.GetInt("HighScore", 0);
        hightScore.text = record.ToString();
        score = 0;

        if(instatiate == null)
        {
            instatiate = this;
        }
    }

    private void UpdateHighScore()
    {
        PlayerPrefs.SetInt("HighScore",score);
        hightScore.text = score.ToString();
    }

    public void UpdateScore()
    {   
        score++;
        currentScore.text = score.ToString();

        if(score > record)
        {
            UpdateHighScore();
        }
    }
}
