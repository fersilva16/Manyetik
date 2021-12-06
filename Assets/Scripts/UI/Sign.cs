using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Sign : MonoBehaviour
{
  [SerializeField]
  [TextArea(1,6)]
  private string[] sentences;

  [SerializeField]
  private GameObject textBox;

  [SerializeField]
  private TMP_Text textMP;

  [SerializeField]
  private AudioSource audioSource;

  [SerializeField]
  private AudioClip audioClip;

  private Queue<string> queue;

  private string activeSentence;

  private bool playerInRange;

  private void OnEnable() => InputManager.Interact += OnInteractInput;
  private void OnDisable() => InputManager.Interact -= OnInteractInput;

  private void Start()
  {
    queue = new Queue<string>();
  }

  private void OnInteractInput(InputAction.CallbackContext context)
  {
    if (!playerInRange) return;

    if (textBox.activeInHierarchy) textBox.SetActive(false);
    else
    {
      textBox.SetActive(true);
      audioSource.PlayOneShot(audioClip);
      StartDialogue();
    }
  }

  public void StartDialogue()
  {
    queue.Clear();

    foreach(string sentence in sentences) queue.Enqueue(sentence);

    DisplayNextSentence();
  }

  public void DisplayNextSentence()
  {
    if (queue.Count <= 0)
    {
      textMP.text = activeSentence;
      return;
    }

    activeSentence = queue.Dequeue();
    textMP.text = activeSentence;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player") && !other.isTrigger) playerInRange = true;
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("Player") && !other.isTrigger)
    {
      playerInRange = false;
      textBox.SetActive(false);
    }
  }
}
