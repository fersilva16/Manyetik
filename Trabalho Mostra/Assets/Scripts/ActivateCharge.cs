using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCharge : MonoBehaviour
{
    [SerializeField] GameObject charge;

    void Start()
    {
        charge.SetActive(false);
    }
    public void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.gameObject.tag == "Player")
        {
            charge.SetActive(true);
        }
    }    

}
