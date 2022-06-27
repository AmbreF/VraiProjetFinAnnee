using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProjectileSpawner : MonoBehaviour
{
    ProjectilePooler projectilePooler;

    private float _lastShoot;
    [SerializeField] private bool _isShooting;

    private float _waitingTime;

    // Start is called before the first frame update
    void Start()
    {
        projectilePooler = ProjectilePooler.Instance;
        _lastShoot = 0f;

        _waitingTime = 0.4f;

    }


    public void Shoot()
    {
        if (_lastShoot <= 0 && _isShooting)
        {
            projectilePooler.SpawnFromPool(transform.position, Quaternion.identity);
            _lastShoot = _waitingTime;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        _lastShoot -= Time.deltaTime;


    }


    public void SetShoot(bool shoot)
    {
        _isShooting = shoot;
    }

    public void SetShootTime(float time)
    {
        _waitingTime = time;
    }

    public float GetShootTime()
    {
        return _waitingTime;
    }

}
