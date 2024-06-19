using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBullet : MonoBehaviour
{

    [SerializeField] private float _rigidbodyForce = 300;
    [SerializeField] private float _bulletLifeTime = 3f;
    private void Awake()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 force = new Vector3(0, 0, _rigidbodyForce);
        rb.AddForce(force, ForceMode.Force);

        Invoke(nameof(DestroyBullet), _bulletLifeTime);
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
