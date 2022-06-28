using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TimerModel : MonoBehaviour
{
    private FloatObservable _secondTime;
    private IntObservable _minuteTime;

    public TimerModel(int second, int minute)
    {
        _secondTime = new FloatObservable(second);
        _minuteTime = new IntObservable(minute);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public IntObservable GetMinute()
    { 
        return _minuteTime; 
    }

    public FloatObservable GetSecond()
    { 
        return _secondTime; 
    }

    public void ChangeTimer()
    {
        _secondTime.Add(-(1 * Time.deltaTime));


        if (_secondTime.GetValue() <= 0 && _minuteTime.GetValue() <= 0)
        {
            Debug.Log("victoire");
        }

        if (_secondTime.GetValue() <= 0)
        {
            _minuteTime.Add(-1);
            _secondTime.Add(59);
        }



    }

}
