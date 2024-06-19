using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveLimit : MonoBehaviour
{
    private string enemyTag = "Enemy";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            Destroy(other.gameObject);
        }
    }
}
