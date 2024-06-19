using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHungerNeed : MonoBehaviour
{
    public static event Action<float> OnEnemyDestroyed;
    [SerializeField] private float _enemyDestroyScore = 1;
    [SerializeField] private float _enemyHungerNeed = 100;
    private float _currentHunger = 0;
    public void TakeFood(float foodHungerScore)
    {
        _currentHunger += foodHungerScore;
        if (_currentHunger > _enemyHungerNeed)
        {
            OnEnemyDestroyed?.Invoke(_enemyDestroyScore);
            Destroy(gameObject);
        }
    }
}
