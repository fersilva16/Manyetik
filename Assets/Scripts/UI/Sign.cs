using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Sign : MonoBehaviour
{
  [SerializeField]
  private GameObject textBox;

  [SerializeField]
  private TMP_Text textMP;

  [SerializeField]
  private string dialogueText;

  private string currentText = "";

  [SerializeField]
  private float delay = 0.1f;

  [SerializeField]
  private bool playerInRange;

  public void OnInteractInput(InputAction.CallbackContext context)
  {
    if (!playerInRange)
    {
      textBox.SetActive(false);
      StopCoroutine(TypewritterEffect());
    }

    if (textBox.activeInHierarchy) textBox.SetActive(false);
    else
    {
      textBox.SetActive(true);
      textMP.text = dialogueText;
      StartCoroutine(TypewritterEffect());
    }
  }

  IEnumerator TypewritterEffect()
  {
    for(int i = 0; i < dialogueText.Length; i++)
    {
      currentText = dialogueText.Substring(0,i);
      textMP.text = currentText;
      yield return new WaitForSeconds(delay);
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player")) playerInRange = true;
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      playerInRange = false;
      textBox.SetActive(false);
      StopCoroutine(TypewritterEffect());
    }
  }
}
