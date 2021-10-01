using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
  [SerializeField]
  private Slider slider;

  [SerializeField]
  private AudioMixer mixer;

  [SerializeField]
  private string volumeParameter = "MasterVolume";

  [SerializeField]
  private float multiplier = 30f;

  public void Awake()
  {
    slider.onValueChanged.AddListener(HandleSliderValueChanged);
  }

  public void OnDisable()
  {
    PlayerPrefs.SetFloat(volumeParameter, slider.value);
  }

  private void HandleSliderValueChanged(float value)
  {
    mixer.SetFloat(volumeParameter, Mathf.Log10(value) * multiplier);
  }

  private void Start()
  {
    slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);
  }
}
