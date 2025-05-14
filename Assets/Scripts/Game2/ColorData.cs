using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorData : MonoBehaviour
{
    public Color color;
    Material material;
    private void Awake()
    {
        material = GetComponent<Material>();
        color = material.color;
    }

}
