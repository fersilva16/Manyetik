using UnityEngine.UI;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
  [SerializeField]
  private Slider volumeSilder;

  private void Start()
  {
    if (!PlayerPrefs.HasKey("soundVolume")) PlayerPrefs.SetFloat("soundVolume", 1);

    Load();
  }

  public void ChangeVolume()
  {
    AudioListener.volume = volumeSilder.value;

    Save();
  }

  private void Load()
  {
    volumeSilder.value = PlayerPrefs.GetFloat("soundVolume");
  }

  private void Save()
  {
    PlayerPrefs.SetFloat("soundVolume", volumeSilder.value);
  }
}
