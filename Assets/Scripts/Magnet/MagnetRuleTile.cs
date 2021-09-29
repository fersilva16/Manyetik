using UnityEngine;

public enum MagnetDirection {
  Conjuction,

  North,
  South,
  West,
  East,
};

public enum PoleType
{
  Conjuction,

  Positive,
  Negative,
};

[CreateAssetMenu(menuName = "2D/Tiles/Custom/Magnet Rule Tile")]
public class MagnetRuleTile : RuleTile
{
  [Header("Magnet")]
  [SerializeField]
  private MagnetDirection direction;

  [SerializeField]
  private PoleType type;

  public MagnetDirection GetDirection() => direction;
  public PoleType GetPoleType() => type;
}
