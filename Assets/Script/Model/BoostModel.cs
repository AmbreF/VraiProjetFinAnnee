using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostModel : MonoBehaviour
{
    [SerializeField] GameObject thisBoost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ouais");

        if (other.tag == "Player")
        {
            Destroy(thisBoost);
        }
            
    }
}