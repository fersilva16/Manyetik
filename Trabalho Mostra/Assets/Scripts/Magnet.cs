using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject magnet;
    public float forceFactor = 1;

    // forceFactor determina a força do magnetismo
    void Start()
    {
        forceFactor = 0;
    }

    private void Update()
    {
        MagnetTrue();
    }
    // Ativa e desativa o magnetismo, se pa da pra usar switch ao inves desses if
    public void MagnetTrue()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            forceFactor = 200;
        }
        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            forceFactor = 200;
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            forceFactor = 0;
        }
        if(Input.GetKeyDown(KeyCode.RightControl))
        {
            forceFactor = 0;
        }
        GetComponent<Rigidbody2D>().AddForce((magnet.transform.position - transform.position) * forceFactor * Time.smoothDeltaTime);
    }
}
