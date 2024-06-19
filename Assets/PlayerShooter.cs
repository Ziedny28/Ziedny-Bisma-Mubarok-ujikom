using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private string _shootAnimationTriggerName = "Shoot";

    private Animator _playerAnimator;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Instantiate(_bulletPrefab, _bulletSpawnPosition.position, Quaternion.identity);
            _playerAnimator.SetTrigger(_shootAnimationTriggerName);
        }
    }
}
