using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerTMPro;
    [SerializeField] private float _time = 60;
    [SerializeField] private Animator _camAnimator;
    [SerializeField] private GameObject _boy;
    [SerializeField] private EnemySpawnerManager _enemySpawnerManager;
    [SerializeField] private string _boyGameOverAnimTriggerName = "EndGame";
    [SerializeField] private string _camGameOverAnimTriggerName = "EndGame";
    private Animator _boyAnimator;
    private bool isGameOver = false;

    private void Awake()
    {
        UpdateTimerText();
        InvokeRepeating(nameof(DecreaseTime), 1, 1);

    }
    private void DecreaseTime()
    {
        if (isGameOver)
        {
            return;
        }
        _time -= 1;
        UpdateTimerText();
        if (_time == 0)
        {
            EndGame();
            isGameOver = true;
        }
    }

    private void UpdateTimerText()
    {
        _timerTMPro.text = $"Timer:{_time}";
    }


    private void EndGame()
    {
        Debug.Log("EndGame");
        SetupBoyEndGame();
        _camAnimator.SetTrigger(_camGameOverAnimTriggerName);
        _enemySpawnerManager.enabled = false;
    }

    private void SetupBoyEndGame()
    {
        PlayerController boyController = _boy.GetComponent<PlayerController>();
        boyController.enabled = false;
        PlayerShooter boyShooter = _boy.GetComponent<PlayerShooter>();
        boyShooter.enabled = false;
        Animator boyAnimator = _boy.GetComponent<Animator>();
        boyAnimator.SetTrigger(_boyGameOverAnimTriggerName);
    }
}
