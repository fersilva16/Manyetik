using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
  [SerializeField]
  private TMP_Text[] scoreTexts;

  private int score;

  private void OnEnable() => Basket.CoinDunk += OnCoinDunk;
  private void OnDisable() => Basket.CoinDunk -= OnCoinDunk;

  private void OnCoinDunk()
  {
    score++;

    foreach (var scoreText in scoreTexts)
    {
      scoreText.text = score.ToString();
    }
  }
}
