using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Product", menuName = "Product")]
public class Products : ScriptableObject //Product Informations
{
    public new string name;

    public Sprite sprite;
}
