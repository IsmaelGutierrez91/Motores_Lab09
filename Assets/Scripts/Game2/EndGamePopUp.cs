using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGamePopUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMP_EndText;
    private void OnLooseGame()
    {
        TMP_EndText.text = "You Loose";
    }
    private void OnWinGame()
    {
        TMP_EndText.text = "You Win";
    }
    private void OnEnable()
    {
        GameManager.OnLoose += OnLooseGame;
        GameManager.OnWin += OnWinGame;
    }
    private void OnDisable()
    {
        GameManager.OnLoose -= OnLooseGame;
        GameManager.OnWin -= OnWinGame;
    }
}
