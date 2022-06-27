using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//float observable

public class IntObservable : IObservable<int>
{
    private List<IObserver<int>> _observers;

    private int _value;

    public int GetValue()
    {
        return _value;
    }

    public IntObservable(int initValue)
    {
        _value = initValue;

        _observers = new List<IObserver<int>>();
    }


    public void Add(int deltaValue)
    {
        _value += deltaValue;

        foreach (IObserver<int> obs in _observers)
        {
            obs.OnNext(_value);
        }
    }




    public IDisposable Subscribe(IObserver<int> observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }

        return null;
    }
}
