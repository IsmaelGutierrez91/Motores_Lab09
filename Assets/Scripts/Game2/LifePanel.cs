using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMP_TextLife;

    private void OnLifeUpdate(int life)
    {
        TMP_TextLife.text = life.ToString();
    }
    private void OnEnable()
    {
        GameManager.OnLifeUpdate += OnLifeUpdate;
    }
    private void OnDisable()
    {
        GameManager.OnLifeUpdate -= OnLifeUpdate;
    }
}
