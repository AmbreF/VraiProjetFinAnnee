using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProjectileSpawner : MonoBehaviour
{
    ProjectilePooler projectilePooler;

    private float _lastShoot;
    [SerializeField] private bool _isEnabled;
    private bool _isShooting;

    [SerializeField]private float _waitingTime;

    // Start is called before the first frame update
    void Start()
    {
        projectilePooler = ProjectilePooler.Instance;
        _lastShoot = 0f;


        _isShooting = false;

    }


    public void Shoot()
    {
        _isShooting=true;

        
    }

    public void UnShoot()
    {
        _isShooting=false;
    }

    // Update is called once per frame
    void Update()
    {
        _lastShoot -= Time.deltaTime;

        if(_isShooting)
        {
            if (_lastShoot <= 0 && _isEnabled)
            {
                projectilePooler.SpawnFromPool(transform.position, Quaternion.identity);
                _lastShoot = _waitingTime;
            }
        }
       

    }


    public void SetShoot(bool shoot)
    {
        _isEnabled = shoot;
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
