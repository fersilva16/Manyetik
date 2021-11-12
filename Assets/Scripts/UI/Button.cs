using UnityEngine;
using ButtonElement = UnityEngine.UI.Button;
using UnityEngine.EventSystems;
using TMPro;
using NaughtyAttributes;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
  [SerializeField]
  private AudioSource audioSource;

  [SerializeField]
  private bool hasHover;

  [Header("Hover")]
  [SerializeField]
  [ShowIf("hasHover")]
  private string text;

  [SerializeField]
  [ShowIf("hasHover")]
  private TextMeshProUGUI targetText;

  [SerializeField]
  [ShowIf("hasHover")]
  private AudioClip hoverAudio;

  [Header("Click")]
  [SerializeField]
  private AudioClip clickAudio;

  private ButtonElement button;

  private void OnEnable()
  {
    button = GetComponent<ButtonElement>();

    button.onClick.AddListener(OnClick);
  }

  private void OnDisable() => button.onClick.RemoveListener(OnClick);

  private void OnClick() => audioSource.PlayOneShot(clickAudio);

  public void OnPointerEnter(PointerEventData eventData)
  {
    if (hasHover)
    {
      targetText.text = text;
      audioSource.PlayOneShot(hoverAudio);
    }
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    if (hasHover) targetText.text = null;
  }
}
