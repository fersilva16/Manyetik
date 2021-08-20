using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutPlayer : MonoBehaviour
{
  [SerializeField] GameObject p;
  [SerializeField] GameObject p1;
  [SerializeField] GameObject p2;

  void Start()
  {
    p.SetActive(true);
    p1.SetActive(false);
    p2.SetActive(false);
  }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.gameObject.CompareTag("Player"))
    {
      p.SetActive(false);
      p1.SetActive(true);
      p2.SetActive(true);
    }
  }
}
