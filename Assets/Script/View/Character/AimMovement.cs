using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _aim;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        transform.up = _aim;
    }



    public Vector2 GetAim()
    {
        return _aim;
    }

    public void SetAim(Vector2 aim)
    {
        _aim = aim;
    }
}
