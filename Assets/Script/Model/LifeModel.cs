using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeModel : MonoBehaviour
{
    [SerializeField] private int _life;
    [SerializeField] private GameObject _thisCharacter;

    [SerializeField] private Animator _animator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_life <= 0)
        {
            if(_thisCharacter.tag == "Ennemies")
            {
                StartCoroutine(Death());
            }else if(_thisCharacter.tag == "Wolves")
            {
                LoadVictory();
            }

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

    public IEnumerator Death()
    {
        
        _animator.SetBool("IsWalkingFront", false);
        _animator.SetBool("IsDead", true);

        

        yield return new WaitForSeconds(0.3f);

        Destroy(_thisCharacter);

    }

    public void LoadVictory()
    {
        SceneManager.LoadScene("Victory");
    }
}
