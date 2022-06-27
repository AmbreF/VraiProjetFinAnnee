using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TimerModel : MonoBehaviour
{
    private int _startingTime;

    private IntObservable  _secondTime;
    private IntObservable _minuteTime;

    // Start is called before the first frame update
    void Start()
    {
        _startingTime = 180;

        _secondTime.Add(_startingTime) ;

        _minuteTime.Add(_secondTime.GetValue() / 60);

        _secondTime.Add(0);
    }

    // Update is called once per frame
    void Update()
    {
        _secondTime.Add(-(1 * (int)Time.deltaTime));

        if(_secondTime.GetValue() <= 0 && _minuteTime.GetValue() <= 0)
        {
            Debug.Log("victoire");
        }

        if(_secondTime.GetValue() <= 0 )
        {
            _minuteTime.Add(-1);
            _secondTime.Add(0);
        }


    }

    public IntObservable GetMinute()
    { 
        return _minuteTime; 
    }

    public IntObservable GetSecond()
    { 
        return _secondTime; 
    }

}
