using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
  public Slider volumeSilder;

  public void Start()
  {
    if(!PlayerPrefs.HasKey("soundVolume"))
    {
        PlayerPrefs.SetFloat("soundVolume", 1);
        Load();
    }
    else
    {
        Load();
    }
  }

  public void ChangeVolume()
  {
    AudioListener.volume = volumeSilder.value;
    Save();
  }

  public void Load()
  {
    volumeSilder.value = PlayerPrefs.GetFloat("soundVolume");
  }

  public void Save()
  {
    PlayerPrefs.SetFloat("soundVolume", volumeSilder.value);
  }
}
