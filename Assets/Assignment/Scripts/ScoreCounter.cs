using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Anytime you need to use TextmeshPro put this here

public class ScoreCounter : MonoBehaviour
{
    TextMeshProUGUI scoreCounter; // There's a difference between TextMeshProUGUI
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveScore()
    {
        int number = 100;
        score.text = number.ToString();
    }
}
