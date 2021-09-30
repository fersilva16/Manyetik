using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMenu : MonoBehaviour
{
  [SerializeField]
  private GameObject volumeMenu;

  public void SoundMenu()
  {
    volumeMenu.SetActive(true);
  }

  public void Back()
  {
    volumeMenu.SetActive(false);
  }
}
