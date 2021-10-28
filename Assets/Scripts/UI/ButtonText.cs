using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonText : MonoBehaviour
{
  [SerializeField]
  public AudioSource hover;

  public string btnText;

  public TextMeshProUGUI text;

  public void OnHover()
  {
    text.text = btnText;
    hover.Play();
  }

  public void OnPointExit()
  {
    text.text = "";
  }
}
