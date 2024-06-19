using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private List<Transform> _spawnPositions;
    private void Awake()
    {
        InvokeRepeating(nameof(SpawnEnemy), _spawnInterval, 1);
    }

    private void SpawnEnemy()
    {
        GameObject randomEnemyToSpawn = RandomEnemy();
        Vector3 randomSpawnPosition = RandomPosition();
        Instantiate(randomEnemyToSpawn, randomSpawnPosition, Quaternion.Euler(0, 180, 0));
    }
    private GameObject RandomEnemy()
    {
        int randomEnemyIndex = Random.Range(0, _enemyPrefabs.Count - 1);
        return _enemyPrefabs[randomEnemyIndex];
    }

    private Vector3 RandomPosition()
    {
        int randomPositionIndex = Random.Range(0, _spawnPositions.Count - 1);
        return _spawnPositions[randomPositionIndex].position;
    }

}
