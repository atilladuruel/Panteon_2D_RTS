using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Buildings")]
public class Buildings : ScriptableObject //Buildings Informations Scriptable Object script
{
    public new string name;

    public Sprite sprite;

    public Vector2 size;

    public List<Products> products;

}
