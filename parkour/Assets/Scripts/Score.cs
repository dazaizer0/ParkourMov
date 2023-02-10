using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI score_text;

    [Header("Settings")]
    public float score;
    public bool timerActive;

    void Start()
    {
        SetScoreText();
    }

    void Update()
    {
        if(timerActive){
            score += Time.deltaTime;
            SetScoreText();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collect")
        {
            score += 5;
            SetScoreText();
        }
    }
    public void SetScoreText(){
        score_text.text = score.ToString("F1");
    }
}