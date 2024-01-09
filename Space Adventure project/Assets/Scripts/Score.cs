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

    private void Start()
    {
        currentScore.text = score.ToString();
        hightScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
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
        if(instatiate == null)
        {
            instatiate = this;
        }
    }

    private void UpdateHighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore",score);
            hightScore.text = score.ToString();
        }
    }

    public void UpdateScore()
    {
        score++;
        currentScore.text = score.ToString();
        UpdateHighScore();
    }
}
