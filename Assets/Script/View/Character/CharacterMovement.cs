using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private Vector2 _move;

    // Start is called before the first frame update
    void Start()
    {

    }

    /*
        _animator.SetBool("Idle", false);
        _animator.SetBool("Walking", true);
     */

    // Update is called once per frame
    void Update()
    {
        if(_move.x >= 0 && _move.y < 0)
        {
            _animator.SetBool("IsWalkingFront",false);
            _animator.SetBool("IsWalkingRight", true);
        }else if (_move.x < 0 && _move.y < 0)
        {
            _animator.SetBool("IsWalkingFront", false);
            _animator.SetBool("IsWalkingLeft", true);
        }else
        {
            _animator.SetBool("IsWalkingFront", true);
            _animator.SetBool("IsWalkingLeft", false);
            _animator.SetBool("IsWalkingRight", false);
        }

        Vector2 m = new Vector2(_move.x, _move.y) * Time.deltaTime * _speed;
        transform.Translate(m, Space.World);

    }



    public Vector2 GetMove()
    {
        return _move;
    }

    public void SetMove(Vector2 move)
    {
        _move = move;

    }

}
