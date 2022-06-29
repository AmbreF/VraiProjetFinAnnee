using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraModel : MonoBehaviour
{
    [SerializeField] private float _auraRange;
    [SerializeField] private LayerMask _ennemyLayers;
    [SerializeField] private SpriteRenderer _sprite;


    private bool _haveBoost;

    // Start is called before the first frame update
    void Start()
    {
        _haveBoost = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_haveBoost)
        {
            _sprite.enabled = true;
        }

    }


    

    public void UseBoost()
    {
        if (_haveBoost)
        {

            FindObjectOfType<AudioManager>().Play("Aura");

            Collider2D[] hitEnnemies = Physics2D.OverlapCircleAll(transform.position, _auraRange, _ennemyLayers);

            foreach (Collider2D ennemy in hitEnnemies)
            {

                //ennemy = hitCollider.GetComponent<LifeModel>();

                ennemy.GetComponent<LifeModel>().SetLife(ennemy.GetComponent<LifeModel>().GetLife() - 5);

                //Debug.Log("Hit : "+ ennemy.name);

            }


            _sprite.enabled = false;
            _haveBoost = false;

        }
    }

    public void SetAuraBoost(bool boost)
    {
        _haveBoost = boost;
    }

}
