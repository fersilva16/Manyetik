using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
  [SerializeField]
  private TMP_Text[] scoreTexts;

  [SerializeField]
  private TMP_Text highScoreText;

  private int score;
  private int highScore;

  private void OnEnable() => Basket.CoinDunk += OnCoinDunk;
  private void OnDisable() => Basket.CoinDunk -= OnCoinDunk;

  private void Start()
  {
    highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
  }

  private void OnCoinDunk()
  {
    score++;

    foreach (var scoreText in scoreTexts)
    {
      scoreText.text = score.ToString();
    }

    PlayerPrefs.SetInt("HighScore", score);
  }
}
