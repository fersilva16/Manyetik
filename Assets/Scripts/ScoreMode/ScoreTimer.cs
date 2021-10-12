using System;
using UnityEngine;
using TMPro;

public class ScoreTimer : MonoBehaviour
{
  [SerializeField]
  private Animator scoreMenuAnimator;

  [SerializeField]
  private GameObject menu;

  [SerializeField]
  private TMP_Text timerText;

  [SerializeField]
  private float startMinutes;

  private float currentTime;

  private void Start()
  {
    Time.timeScale = 1f;
    currentTime = startMinutes * 60;
    UpdateText();
  }

  private void Update()
  {
    currentTime -= Time.deltaTime;

    if (currentTime <= 0)
    {
      Time.timeScale = 0f;

      scoreMenuAnimator.Play("Open");

      menu.SetActive(false);

      return;
    }

    UpdateText();
  }

  private void UpdateText()
  {
    TimeSpan time = TimeSpan.FromSeconds(currentTime);

    timerText.text = time.ToString(@"mm\:ss");
  }
}
