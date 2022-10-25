using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuilder : MonoBehaviour
{
    private void Start()
    {
        Grid grid = new Grid(42, 23, 1f, transform.position);
    }
}
