using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private string _animFloatParamId = "HorizontalInput";
    [SerializeField] private string _animTriggerIdleParamId = "Idle";
    [SerializeField] private float _moveSpeedNormalizer = 0.3f;
    private CharacterController _controller;
    private Animator _animator;
    // Start is called before the first frame update
    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * _moveSpeedNormalizer;
        _animator.SetFloat(_animFloatParamId, horizontalInput);
        if (horizontalInput == 0)
        {
            _animator.SetTrigger(_animTriggerIdleParamId);
        }
        Vector3 _playerMove = new Vector3(horizontalInput, 0, 0);
        _controller.Move(_playerMove);
    }
}
