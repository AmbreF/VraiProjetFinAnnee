using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProjectile : MonoBehaviour,IPooledProjectile
{
    [SerializeField] float _speed;
    [SerializeField] float _cameraSpeed;

    [SerializeField] GameObject thisObject;

    private Vector3 _characterAim;

    private float _rotationZ;




    public void OnProjectileSpawn()
    {
        //Vector2 projectile = new Vector2(_characterAim.transform.position.x - _character.transform.position.x, _characterAim.gameObject.transform.position.y - _character.transform.position.y);

        //GetComponent<Rigidbody2D>().velocity = _characterAim.normalized *_speed + new Vector3(0f, Time.deltaTime * 1, 0f);

       

    }



    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * (_speed + _cameraSpeed) * Time.deltaTime);


        transform.eulerAngles = new Vector3(0, 0, _rotationZ);
    }



    public void SetCharacterAim(Vector3 aim)
    {
        _characterAim = aim;

        _rotationZ = (float)(Math.Atan2(aim.y, aim.x)/Math.PI*180)-90;


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Heal" && other.tag != "Aura" && other.tag != "ShootBoost" && other.tag != "Wall" && other.tag != "Wave")
        {
            thisObject.SetActive(false);
        }
    }


}
