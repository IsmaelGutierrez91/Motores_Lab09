using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.EditorUtilities;

public class CoinPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMP_TextConis;

    private void OnCoinsUpdate(int coins)
    {
        TMP_TextConis.text = coins.ToString();
    }
    private void OnEnable()
    {
        GameManager.OnCoinsUpdate += OnCoinsUpdate;
    }
    private void OnDisable()
    {
        GameManager.OnCoinsUpdate -= OnCoinsUpdate;
    }
}
