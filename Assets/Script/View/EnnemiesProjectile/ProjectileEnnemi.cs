using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnnemi : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( 0f, -(_speed*Time.deltaTime), 0f);
    }

    private void OnBecameInvisible()
    {
        Destroy(_projectile);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(_projectile);
    }
}
