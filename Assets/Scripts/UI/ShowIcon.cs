using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIcon : MonoBehaviour
{
  public Sign sign;

  [SerializeField]
  private GameObject icon;

  private void Update()
  {
    if(sign.playerInRange == true)
    {
      icon.SetActive(true);
    }else
    {
      icon.SetActive(false);
    }
  }
}
