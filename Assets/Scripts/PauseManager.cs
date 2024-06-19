using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI;
    bool _isPaused = false;

    private void Awake()
    {
        _pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        _isPaused = !_isPaused;
        if (_isPaused)
        {
            Time.timeScale = 0;
            _pauseMenuUI.SetActive(true);
        }
        if (!_isPaused)
        {
            ResumeGame();
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        _pauseMenuUI.SetActive(false);
    }
}
