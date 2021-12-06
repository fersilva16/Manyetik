using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Sign : MonoBehaviour
{
  public SignSentences singSenteces;

  Queue<string> sentences;

  string activeSentence;

  public GameObject textBox;

  [SerializeField]
  private TMP_Text textMP;

  [SerializeField]
  private AudioSource audioSource;
  [SerializeField]
  private AudioClip audioClip;

  private bool playerInRange;

  private void OnEnable() => InputManager.Interact += OnInteractInput;
  private void OnDisable() => InputManager.Interact -= OnInteractInput;

  private void Start()
  {
    sentences = new Queue<string>();
  }

  private void OnInteractInput(InputAction.CallbackContext context)
  {
    if(!playerInRange) return;

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
    sentences.Clear();

    foreach(string sentence in singSenteces.sentenceList)
    {
      sentences.Enqueue(sentence);
    }

    DisplayNextSentence();
  }

  public void DisplayNextSentence()
  {
    if(sentences.Count <= 0)
    {
      textMP.text = activeSentence;
      return;
    }

    activeSentence = sentences.Dequeue();
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
