using UnityEngine;

public class PlayerMagnetism : MonoBehaviour
{
  [SerializeField]
  private GameObject[] poles;

  [SerializeField]
  private bool magnetized = true;

  private void OnEnable()
  {
    Fire.Collided += OnFireCollided;
    Magnetite.Collided += OnMagnetiteCollided;
  }

  private void OnDisable()
  {
    Fire.Collided -= OnFireCollided;
    Magnetite.Collided -= OnMagnetiteCollided;
  }

  private void OnFireCollided() => ChangeMagnetized(false);
  private void OnMagnetiteCollided() => ChangeMagnetized(true);

  private void Start() => ChangeMagnetized(magnetized);

  private void ChangeMagnetized(bool value)
  {
    magnetized = value;

    foreach (var pole in poles) pole.SetActive(value);
  }

  public bool IsMagnetized() => magnetized;
}
