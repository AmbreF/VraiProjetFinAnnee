using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartView : MonoBehaviour
{
    [SerializeField] GameObject heart;


    public void HeartSee()
    {
        heart.SetActive(true);
    }

    public void HeartUnSee()
    {
        heart.SetActive(false);
    }
}
