using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ColorObject : MonoBehaviour
{
    [SerializeField] private ColorShapeData colorData;
    private SpriteRenderer spriteRenderer;
    public static event Action<Color> OnChangeColor;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorData.color = spriteRenderer.color;
    }
    private void Update()
    {
        SetUp();
    }
    private void SetUp()
    {
        spriteRenderer.color = colorData.color;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnChangeColor?.Invoke(colorData.color);
        }
    }
}
