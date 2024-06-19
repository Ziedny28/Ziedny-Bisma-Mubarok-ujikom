using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float _enemySpeed = 0.1f;
    private CharacterController _enemyController;
    private void Awake()
    {
        _enemyController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _enemyController.Move(new Vector3(0, 0, -_enemySpeed));
    }
}
