using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PoleMapping
{
  private enum TileType
  {
    Null,
    Positive,
    Negative,
    Marked,
  }

  private int width;
  private int height;

  private int totalArea;

  private TileType[,] matrix;

  public PoleMapping(Tilemap tilemap)
  {
    width = tilemap.cellBounds.size.x;
    height = tilemap.cellBounds.size.y;

    matrix = new TileType[width, height];

    for (var i = 0; i < width; i++)
    {
      for (var j = 0; j < height; j++)
      {
        var tile = tilemap.GetTile<MagnetRuleTile>(
          new Vector3Int(
            i + tilemap.cellBounds.min.x,
            j + tilemap.cellBounds.min.y,
            0
          )
        );

        if (tile == null) matrix[i, j] = TileType.Null;
        else
        {
          switch (tile.GetPoleType())
          {
            case PoleType.Negative:
              matrix[i, j] = TileType.Negative;
              totalArea++;
              break;
            case PoleType.Positive:
              matrix[i, j] = TileType.Positive;
              totalArea++;
              break;
            default:
              matrix[i, j] = TileType.Marked;
              break;
          }
        }
      }
    }
  }

  private List<BoundsInt> FindAll()
  {
    var poles = new List<BoundsInt>();
    var area = 0;

    while (area < totalArea)
    {
      var min = FindPoleFirstCorner(out var tileType);
      var max = FindPoleSecondCorner(tileType, min);
      var pole = new BoundsInt(min, max - min);

      poles.Add(pole);

      MarkPole(pole);

      area += (pole.size.x + 1) * (pole.size.y + 1);
    }

    return poles;
  }

  private Vector3Int FindPoleFirstCorner(out TileType tileType)
  {
    for (var i = 0; i < width; i++)
    {
      for (var j = 0; j < height; j++)
      {
        switch (matrix[i, j])
        {
          case TileType.Negative:
          case TileType.Positive:
            tileType = matrix[i, j];
            return new Vector3Int(i, j, 0);
        }
      }
    }

    throw new Exception("First corner not found.");
  }

  private Vector3Int FindPoleSecondCorner(TileType tileType, Vector3Int min)
  {
    var max = new Vector3Int(width - 1, height - 1, 0);

    for (var i = min.x; i <= max.x; i++)
    {
      if (matrix[i, min.y] != tileType)
      {
        max.x = i - 1;

        break;
      }

      for (var j = min.y; j <= max.y; j++)
      {
        if (matrix[i, j] != tileType)
        {
          max.y = j - 1;

          break;
        }
      }
    }

    return max;
  }

  private void MarkPole(BoundsInt bounds)
  {
    for (var i = bounds.min.x; i <= bounds.max.x; i++)
    {
      for (var j = bounds.min.y; j <= bounds.max.y; j++)
      {
        matrix[i, j] = TileType.Marked;
      }
    }
  }

  public static List<BoundsInt> FindPoles(Tilemap tilemap)
  {
    var poleMapping = new PoleMapping(tilemap);

    return poleMapping.FindAll();
  }
}
