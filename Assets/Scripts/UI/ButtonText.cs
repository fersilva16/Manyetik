using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonText : MonoBehaviour
{
  public string btnText;

  public TextMeshProUGUI text;

  public void OnHover()
  {
    text.text = btnText;
  }

  public void OnPointExit()
  {
    text.text = "";
  }
}
