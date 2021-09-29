using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class MagnetManager : MonoBehaviour
{
  [SerializeField]
  private Tilemap tilemap;

  [Header("Magnet Options")]
  [SerializeField]
  private LayerMask positiveMask;

  [SerializeField]
  private LayerMask negativeMask;

  [SerializeField]
  private float heightOffset;

  [SerializeField]
  private float widthOffset;

  [SerializeField]
  private float force;

  private List<GameObject> gameObjects = new List<GameObject>();

  private void Awake()
  {
    transform.position = tilemap.localBounds.min;

    var poles = PoleMapping.FindPoles(tilemap);

    for (var i = 0; i < poles.Count; i++) CreateGameObject(i, poles[i]);
  }

  private void CreateGameObject(int id, BoundsInt bounds)
  {
    var pole = new GameObject($"Pole{id}");
    var collider2D = pole.AddComponent<CapsuleCollider2D>();
    var effector2D = pole.AddComponent<AreaEffector2D>();

    var tile = tilemap.GetTile<MagnetRuleTile>(bounds.min + tilemap.cellBounds.min);

    var size = (Vector2Int) bounds.size + Vector2Int.one;
    var offset = new Vector2(widthOffset, heightOffset);

    var colliderSize = size + offset;
    var colliderOffset = new Vector2(0, colliderSize.y / 2);
    var colliderMask = negativeMask;

    var forceAngle = 90;

    switch (tile.GetDirection())
    {
      case MagnetDirection.South:
        colliderMask = positiveMask;
        forceAngle = -90;
        pole.transform.Rotate(0, 0, 180);
        break;
      // case MagnetDirection.West:
      //   colliderOffset = -colliderSize / 2;
      //   collider2D.direction = CapsuleDirection2D.Vertical;
      //   pole.transform.Rotate(0, 0, -90);
      //   break;
      // case MagnetDirection.East:
      //   colliderOffset = colliderSize / 2;
      //   collider2D.direction = CapsuleDirection2D.Vertical;
      //   pole.transform.Rotate(0, 0, 90);
      //   break;
    }

    collider2D.isTrigger = true;
    collider2D.usedByEffector = true;
    collider2D.size = colliderSize;
    collider2D.offset = colliderOffset;

    effector2D.useColliderMask = true;
    effector2D.colliderMask = colliderMask;
    effector2D.forceAngle = forceAngle;
    effector2D.forceMagnitude = force;

    if (tile.GetPoleType() == PoleType.Positive) effector2D.forceAngle *= -1;

    pole.transform.SetParent(transform);
    pole.transform.localPosition = (Vector2Int) bounds.min + ((Vector2)size / 2);

    gameObjects.Add(pole);
  }

  public void OnInvertInput(InputAction.CallbackContext _)
  {
    foreach (var gameObject in gameObjects)
    {
      gameObject.GetComponent<AreaEffector2D>().forceAngle *= -1;
    }
  }
}
