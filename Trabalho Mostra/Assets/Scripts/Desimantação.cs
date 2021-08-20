using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desimantação : MonoBehaviour
{
  [SerializeField] GameObject ferro;
  [SerializeField] GameObject ima;

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.gameObject.CompareTag("Player"))
    {
      ferro.SetActive(true);
      ima.SetActive(false);
    }
  }
}
