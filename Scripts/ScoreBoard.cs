using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{

    [SerializeField] private int _score;
    
    [SerializeField] private TextMeshProUGUI scoreText;

    public void Awake()
    {
        TreeHouse.OnPointsGained += AddToScore;
    }
    
    private void AddToScore(int pointsGained)
    {
        _score += pointsGained;

        Debug.Log($"{_score}");
        
        scoreText.text = $"{_score}";
    }
    
}
