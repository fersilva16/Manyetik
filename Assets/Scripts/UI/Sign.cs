using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Sign : MonoBehaviour
{
  [SerializeField]
  private GameObject textBox;

  [SerializeField]
  private TMP_Text text;

  [SerializeField]
  private string dialog;

  [SerializeField]
  private bool playerInRange;

  public void OnInteractInput(InputAction.CallbackContext context)
  {
    if (!playerInRange) return;

    if (textBox.activeInHierarchy) textBox.SetActive(false);
    else
    {
      textBox.SetActive(true);
      text.text = dialog;
    }
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
