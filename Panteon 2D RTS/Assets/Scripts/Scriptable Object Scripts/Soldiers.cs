using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Soldier", menuName = "Soldiers")]
public class Soldiers : ScriptableObject
{
    public new string name;

    public Sprite sprite;

    public Vector2 size;
}