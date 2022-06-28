using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : MonoBehaviour
{

    [SerializeField] private int _life;
    [SerializeField] private GameObject _thisCharacter;


    private int _lifeMax;
    private float _lastHit;

    private bool _boostAura;
    private bool _boostShoot;

    public bool _isTouchingWall;

    // Start is called before the first frame update
    void Start()
    {
        _lifeMax = _life;
        _lastHit = 0f;

        _boostAura = false;
        _boostShoot = false;

        _isTouchingWall = false;

    }

    // Update is called once per frame
    void Update()
    {
        _lastHit -= Time.deltaTime;


    }

    public bool GetAuraBoost()
    {

        return _boostAura;
    }

    public void SetAuraBoost(bool aura)
    {
        _boostAura = aura;
    }

    public bool GetShootBoost()
    {

        return _boostShoot;
    }

    public void SetShotBoost(bool shoot)
    {
        _boostShoot = shoot;
    }


    public int GetLife()
    {

        return _life;
    }

    public void SetLife(int life)
    {
        _life = life;
    }





    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Aura")
        {
            _boostAura = true;

        }else if(other.tag == "Heal")
        {

            if(_life < _lifeMax)
            {
                _life++;

            }

        }
        else if (other.tag == "ShootBoost")
        {
            Debug.Log("Shoot");

            _boostShoot = true;
        }
        else if (other.tag == "Ennemies")
        {
            if(_lastHit <= 0)
            {
                _life--;

                _lastHit = 3f;

            }
        }
        else if (other.tag == "Wall")
        {
            _isTouchingWall = true;
        }
        


        if (other.tag == "Edge")
        {
            if(_isTouchingWall)
            {
                _life = 0;
            }

        }
        


        if (_life <= 0)
        {
            Destroy(_thisCharacter);
        }

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            _isTouchingWall = false;
        }
    }
}
