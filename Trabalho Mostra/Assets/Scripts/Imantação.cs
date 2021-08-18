using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imantação : MonoBehaviour
{
    [SerializeField] GameObject ferro;
    [SerializeField] GameObject ima;
    void Start()
    {
        ferro.SetActive(true);
        ima.SetActive(false);
        
    }  
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            ferro.SetActive(false);
            ima.SetActive(true);
        }
        
    }
}
