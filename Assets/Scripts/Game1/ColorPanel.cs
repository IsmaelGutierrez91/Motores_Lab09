using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPanel : MonoBehaviour
{
    private Image colorImage;
    private void Awake()
    {
        colorImage = GetComponent<Image>();
    }
    private void UpdateColor(Color newColor)
    {
        colorImage.color = newColor;
    }
    private void OnEnable()
    {
        ColorObject.OnChangeColor += UpdateColor;
    }
    private void OnDisable()
    {
        ColorObject.OnChangeColor -= UpdateColor;
    }
}
