using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerColorShapeController : MonoBehaviour
{
    [SerializeField] private ColorShapeData playerData;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerData.color = spriteRenderer.color;
        playerData.sprite = spriteRenderer.sprite;
    }
    private void Update()
    {
        SetUp();
    }
    private void SetUp()
    {
        spriteRenderer.color = playerData.color;
        spriteRenderer.sprite = playerData.sprite;
    }
    private void UpdateColor(Color newColor)
    {
        playerData.color = newColor;
    }
    private void UpdateShape(Sprite newSprite)
    {
        playerData.sprite = newSprite;
    }
    private void OnEnable()
    {
        ShapeObject.OnChangeShape += UpdateShape;
        ColorObject.OnChangeColor += UpdateColor;
    }
    private void OnDisable()
    {
        ShapeObject.OnChangeShape -= UpdateShape;
        ColorObject.OnChangeColor -= UpdateColor;
    }
}
