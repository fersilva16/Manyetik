using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sign : MonoBehaviour
{
  public GameObject textBox;
  public TMP_Text text;
  public string dialog;
  public bool playerInRange;

  void Start()
  {
        
  }

  void Update()
  {
    if(Input.GetKeyDown(KeyCode.W) && playerInRange)
    {
        if(textBox.activeInHierarchy)
        {
            textBox.SetActive(false);
        }
        else
        {
            textBox.SetActive(true);
            text.text = dialog;
        }
    }
  }

  private void OnTriggerEnter2D(Collider2D col)
  {
    if(col.CompareTag("Player"))
    {
      playerInRange = true;
    }
  }

  private void OnTriggerExit2D(Collider2D col)
  {
    playerInRange = false;
  }
}
