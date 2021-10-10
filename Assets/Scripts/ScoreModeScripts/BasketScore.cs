using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BasketScore : MonoBehaviour
{
  [SerializeField]
  private int score;

  [SerializeField]
  private TMP_Text scoreText;

  void Start()
  {

  }

  void Update()
  {

  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    Destroy(other.gameObject);
    AddScore();
  }

  public void AddScore()
  {
    score++;
    scoreText.text = score.ToString();
  }


}
