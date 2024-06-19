using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreTMPro;
    private float _currentScore = 0;

    private void OnEnable()
    {
        EnemyHungerNeed.OnEnemyDestroyed += UpdateScore;
    }

    private void OnDisable()
    {
        EnemyHungerNeed.OnEnemyDestroyed -= UpdateScore;
    }

    private void UpdateScore(float score)
    {

        _currentScore += score;
        _scoreTMPro.text = $"Score: {_currentScore}";
    }
}
