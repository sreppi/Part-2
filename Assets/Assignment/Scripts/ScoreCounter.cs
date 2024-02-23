using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Anytime you need to use TextmeshPro put this here

public class ScoreCounter : MonoBehaviour
{
    TextMeshProUGUI scoreCounter; // There's a difference between TextMeshProUGUI
    public int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        scoreCounter = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounter.text = currentScore.ToString();
    }

    public void ReceiveScore(int points)
    {
        Debug.Log("Point!");
        currentScore += points;
    }
}
