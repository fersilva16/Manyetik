using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMenu : MonoBehaviour
{
  [SerializeField]
  private GameObject volumeMenu;

  [SerializeField]
  private Animator animationVM;

  public void SoundMenu()
  {
    animationVM.Play("VolumeMenu");
  }

  public void Back()
  {
    animationVM.Play("VolumeMenu_2");
  }
}
