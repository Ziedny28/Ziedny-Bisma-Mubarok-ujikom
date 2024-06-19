using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHungerNeed : MonoBehaviour
{
    [SerializeField] private float _enemyHungerNeed = 100;
    private float _currentHunger = 0;
    public void TakeFood(float foodHungerScore)
    {
        _currentHunger += foodHungerScore;
        if (_currentHunger > _enemyHungerNeed)
        {
            Destroy(gameObject);
        }
    }
}
