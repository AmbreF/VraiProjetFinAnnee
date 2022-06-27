using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiesProjectileSpawner : MonoBehaviour
{
    private float _lastShoot;
    [SerializeField] GameObject _projectile;

    // Start is called before the first frame update
    void Start()
    {
        _lastShoot = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        _lastShoot -= Time.deltaTime;

        if (_lastShoot <= 0)
        {
            Instantiate(_projectile, transform.position, transform.rotation);
            _lastShoot = 0.6f;
        }
    }
}
