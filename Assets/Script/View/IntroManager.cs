using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    [SerializeField] GameObject text3;
    [SerializeField] GameObject text4;
    [SerializeField] GameObject button;
    [SerializeField] Button button2;

    private int _clic;

    // Start is called before the first frame update
    void Start()
    {
        _clic = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Skip()
    {
        if(_clic == 0)
        {
            text1.SetActive(false);
            text2.SetActive(true);

            _clic++;
        }
        else if(_clic == 1)
        {
            text2.SetActive(false);
            text3.SetActive(true);
            _clic++;
        }
        else if(_clic == 2)
        {
            text3.SetActive(false);
            text4.SetActive(true);
            _clic++;
        }
        else if (_clic == 3)
        {
            text4.SetActive(false);
            button.SetActive(false);
            button2.Select();

        }
    }
}
