using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraModel : MonoBehaviour
{
    [SerializeField] private float _auraRange;
    [SerializeField] private LayerMask _ennemyLayers;
    [SerializeField] private GameObject _boost;
    [SerializeField] private SpriteRenderer _auraView;


    private bool _haveBoost;

    // Start is called before the first frame update
    void Start()
    {
        _haveBoost = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        _boost.SetActive(_haveBoost);
        

    }


    

    public void UseBoost()
    {
        if (_haveBoost)
        {

            FindObjectOfType<AudioManager>().Play("Aura");

            Collider2D[] hitEnnemies = Physics2D.OverlapCircleAll(transform.position, _auraRange, _ennemyLayers);

            _auraView.enabled = true;

            foreach (Collider2D ennemy in hitEnnemies)
            {

                //ennemy = hitCollider.GetComponent<LifeModel>();

                ennemy.GetComponent<LifeModel>().SetLife(ennemy.GetComponent<LifeModel>().GetLife() - 10);

                //Debug.Log("Hit : "+ ennemy.name);

            }


            _haveBoost = false;

            StartCoroutine(UseAura());

        }
    }

    public void SetAuraBoost(bool boost)
    {
        _haveBoost = boost;
    }

    public IEnumerator UseAura()
    {
        
        yield return new WaitForSeconds(0.5f);

        _auraView.enabled = false;
    }


}
