using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EnemyHungerNeed : MonoBehaviour
{
    public static event Action<float> OnEnemyDestroyed;
    [SerializeField] private float _enemyDestroyScore = 1;
    [SerializeField] private float _enemyHungerNeed = 100;
    [SerializeField] private GameObject _sliderPrefab;
    [SerializeField] private GameObject _vfxDestroyPrefab;
    private Slider _healthSlider;
    private float _currentHunger = 0;
    private Camera cam;
    private GameObject sliderObject;
    float sliderContent = 0;


    private void OnEnable()
    {
        TimerManager.OnEndGame += EndGame;
    }

    private void OnDisable()
    {
        TimerManager.OnEndGame -= EndGame;
    }

    private void Awake()
    {
        cam = Camera.main;
        sliderObject = Instantiate(_sliderPrefab, cam.WorldToScreenPoint(transform.position), Quaternion.identity);
        _healthSlider = sliderObject.GetComponentInChildren<Slider>();
        _healthSlider.maxValue = _enemyHungerNeed;
    }

    private void Update()
    {
        _healthSlider.transform.position = cam.WorldToScreenPoint(transform.position);
    }

    public void TakeFood(float foodHungerScore)
    {
        _currentHunger += foodHungerScore;
        sliderContent += _currentHunger;
        Debug.Log($"sliderContent{sliderContent}");
        _healthSlider.value = sliderContent;
        if (_currentHunger > _enemyHungerNeed)
        {
            OnEnemyDestroyed?.Invoke(_enemyDestroyScore);
            Destroy(sliderObject);
            Destroy(gameObject);

        }
    }

    private void EndGame()
    {
        Destroy(sliderObject);
    }
}
