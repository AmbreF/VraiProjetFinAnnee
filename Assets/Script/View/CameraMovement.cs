using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0f, Time.deltaTime * _speed, 0f) );
    }


    public void SetSpeed(float deltaSpeed)
    {
        _speed = deltaSpeed;
    }
}
