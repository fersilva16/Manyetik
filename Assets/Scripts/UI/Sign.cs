using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Sign : MonoBehaviour
{
  [SerializeField]
  private GameObject textBox;

  [SerializeField]
  private TMP_Text text;

  [SerializeField]
  private string[] dialogues;

  [SerializeField]
  private bool playerInRange;

  public void OnInteractInput(InputAction.CallbackContext context)
  {
    if (!playerInRange) return;

    if (textBox.activeInHierarchy) textBox.SetActive(false);
    else
    {
      textBox.SetActive(true);
      text.text = dialogues[0];
    }
  }

  public void NextDialogue()
  {
    text.text = dialogues[1];
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.CompareTag("Player")) playerInRange = true;
  }

  private void OnTriggerExit2D(Collider2D collider)
  {
    playerInRange = false;
    textBox.SetActive(false);
  }
}
