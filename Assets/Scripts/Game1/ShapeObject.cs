using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeObject : MonoBehaviour
{
    [SerializeField] private ColorShapeData shapeData;
    private SpriteRenderer spriteRenderer;
    public static event Action<Sprite> OnChangeShape;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shapeData.sprite = spriteRenderer.sprite;
    }
    private void Update()
    {
        SetUp();
    }
    private void SetUp()
    {
        spriteRenderer.sprite = shapeData.sprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnChangeShape?.Invoke(shapeData.sprite);
        }
    }
}
