using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorProperty : MonoBehaviour
{
    [SerializeField] protected ColorData colorData;
    protected MeshRenderer meshRenderer;
    protected Material material;

    protected void Start()
    {
        material = meshRenderer.material;
        SetUpColor(colorData);
    }
    protected void SetUpColor(ColorData newColor)
    {
        colorData = newColor;
        material.SetColor("Red", colorData.color);
    }
}
