using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private float cellsize;
    private int[,] gridArray;

    public Grid(int width, int height, float cellsize)
    {
        this.width = width;
        this.height = height;
        this.cellsize = cellsize;

        gridArray = new int[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Debug.Log(x + " " + y);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }

        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    public Grid(int width, int height, float cellsize, Vector2 position)
    {
        this.width = width;
        this.height = height;
        this.cellsize = cellsize;

        gridArray = new int[width, height];

        for (float x = position.x; x < position.x + width; x++)
        {
            for (float y = position.y; y < position.y + height; y++)
            {
                Debug.Log(x + " " + y);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }

        Debug.DrawLine(GetWorldPosition(position.x, position.y + height), GetWorldPosition(position.x + width, position.y + height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(position.x + width, position.y), GetWorldPosition(position.x + width, position.y + height), Color.white, 100f);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellsize;
    }

    private Vector3 GetWorldPosition(float x, float y)
    {
        return new Vector3(x, y) * cellsize;
    }
}
