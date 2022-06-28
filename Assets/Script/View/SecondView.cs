using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SecondView : MonoBehaviour, IObserver<float>
{
    [SerializeField] private TextMeshProUGUI _time;

    private int _second;

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(float value)
    {

        _second = (int)value;

        //Mise à jour du texte
        _time.text = _second.ToString();

    }

    // Start is called before the first frame update
    void Start()
    {
        _second = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
