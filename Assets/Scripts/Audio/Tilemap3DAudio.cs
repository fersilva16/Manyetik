using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using NaughtyAttributes;

public class Tilemap3DAudio : MonoBehaviour
{
  [SerializeField]
  private GameObject player;

  [SerializeField]
  private Tilemap tilemap;

  [Header("Audio Options")]
  [SerializeField]
  private AudioSource audioSource;

  [SerializeField]
  private float updateRate;

  [Space]
  [CurveRange(0, 0, 1, 1)]
  [SerializeField]
	private AnimationCurve volumeCurve;

  private List<Vector2Int> tilesPosition;

  private void Start()
  {
    tilesPosition = new List<Vector2Int>();

    for (var i = 0; i < tilemap.cellBounds.size.x; i++)
    {
      for (var j = 0; j < tilemap.cellBounds.size.y; j++)
      {
        var position = new Vector2Int(
          i + tilemap.cellBounds.min.x,
          j + tilemap.cellBounds.min.y
        );

        var hasTile = tilemap.HasTile((Vector3Int) position);

        if (hasTile) tilesPosition.Add(position);
      }
    }

    if (tilesPosition.Count > 0) StartCoroutine(AdjustVolume());
  }

  private IEnumerator AdjustVolume()
  {
    while (true)
    {
      if (audioSource.isPlaying)
      {
        float distance = 0;

        foreach (var tilePosition in tilesPosition)
        {
          var tileDistance = Vector2.Distance(player.transform.position, tilePosition);

          if (distance == 0 || tileDistance < distance) distance = tileDistance;

          if (tileDistance < 1) break;
        }

        if (distance < 1) distance = 1;

        audioSource.volume = volumeCurve.Evaluate(1 / distance);
      }

      yield return new WaitForSeconds(.1f);
    }
  }
}
