using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapePanel : MonoBehaviour
{
    private Image shapeImage;
    private void Awake()
    {
        shapeImage = GetComponent<Image>();
    }
    private void UpdateShape(Sprite newSprite)
    {
        shapeImage.sprite = newSprite;
    }
    private void OnEnable()
    {
        ShapeObject.OnChangeShape += UpdateShape;
    }
    private void OnDisable()
    {
        ShapeObject.OnChangeShape -= UpdateShape;
    }
}
