using UnityEngine;

public class ShowIcon : MonoBehaviour
{
  public Sign sign;

  [SerializeField]
  private GameObject icon;

  [SerializeField]
  private bool show = true;

  private void Update()
  {
    if(show && sign.playerInRange)
    {
      icon.SetActive(true);
    }
    else
    {
      icon.SetActive(false);
    }
  }
}
