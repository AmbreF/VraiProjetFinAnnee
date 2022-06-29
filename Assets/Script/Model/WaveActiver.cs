using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveActiver : MonoBehaviour
{
    [SerializeField] GameObject waveActiver;

  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Edge")
        {
            waveActiver.SetActive(true);

        }
    }


    
}
