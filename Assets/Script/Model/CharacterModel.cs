using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterModel : MonoBehaviour
{

    [SerializeField] private int _life;
    [SerializeField] private Animator _animator;


    private int _lifeMax;
    private float _lastHit;

    private bool _boostAura;
    private bool _boostShoot;

    private bool _isTouchingWall;

    private bool _isDead;


    // Start is called before the first frame update
    void Start()
    {
        _lifeMax = _life;
        _lastHit = 0f;

        _boostAura = false;
        _boostShoot = false;

        _isTouchingWall = false;
        _isDead = false;

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


    public bool GetDeath()
    {

        return _isDead;
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
            FindObjectOfType<AudioManager>().Play("Boost");

            _boostAura = true;

        }else if(other.tag == "Heal")
        {
            FindObjectOfType<AudioManager>().Play("Boost");

            if (_life < _lifeMax)
            {
                _life++;

            }

        }
        else if (other.tag == "ShootBoost")
        {
            FindObjectOfType<AudioManager>().Play("Boost");

            Debug.Log("Shoot");

            _boostShoot = true;
        }
        else if (other.tag == "Ennemies" || other.tag == "Wolfes")
        {
            FindObjectOfType<AudioManager>().Play("Blessure");

            if (_lastHit <= 0)
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
            StartCoroutine(Death());
        }

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            _isTouchingWall = false;
        }
    }

    

    public IEnumerator Death()
    {
        _isDead = true;

        _animator.SetBool("IsWalkingFront", false);
        _animator.SetBool("IsDead", true);

        yield return new WaitForSeconds(3);

        LoadDefeat();
    }

    public void LoadDefeat()
    {
        SceneManager.LoadScene("Defeat");
    }
}
