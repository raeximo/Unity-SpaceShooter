using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UIdisplay : MonoBehaviour
{

    [Header("health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
      
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

    }


    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
    }
}
