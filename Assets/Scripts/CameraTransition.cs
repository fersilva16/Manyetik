using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
  public GameObject virtualCam;

  public void OnTriggerEnter2D(Collider2D col)
  {
    if(col.CompareTag ("Player") && !col.isTrigger)
    {
        virtualCam.SetActive (true);
    }
  }

  public void OnTriggerExit2D(Collider2D col)
  {
    if(col.CompareTag ("Player") && !col.isTrigger)
    {
        virtualCam.SetActive (false);
    }
  }
}
