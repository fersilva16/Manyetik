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

  private bool playerInRange;

  private void OnEnable() => InputManager.Interact += OnInteractInput;
  private void OnDisable() => InputManager.Interact -= OnInteractInput;

  private void OnInteractInput(InputAction.CallbackContext context)
  {
    if(!playerInRange)
    return;

    if (textBox.activeInHierarchy) textBox.SetActive(false);
    else
    {
      textBox.SetActive(true);
      textMP.text = dialogueText;
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
    }
  }
}
