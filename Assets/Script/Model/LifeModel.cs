using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeModel : MonoBehaviour
{
    [SerializeField] private int _life;
    [SerializeField] private GameObject _thisCharacter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_life <= 0)
        {
            Destroy(_thisCharacter);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Tir")
        {
            _life--;

        }

    }

    public void SetLife(int addLife)
    {
        _life = addLife;
    }

    public int GetLife()
    {
        return _life;
    }
}
