using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerSlide : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            player.gameObject.transform.Rotate(new Vector3(0, 0, 180f));
        }
    }
}
