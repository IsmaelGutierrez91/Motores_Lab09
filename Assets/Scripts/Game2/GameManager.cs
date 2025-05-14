using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int playerLife = 10;
    [SerializeField] private int playerCoins = 0;
    public static event Action<int> OnLifeUpdate;
    public static event Action<int> OnCoinsUpdate;
    public static event Action OnWin;
    public static event Action OnLoose;

    public Image EndGamePopUp;
    private void Awake()
    {
        playerLife = 10;
        EndGamePopUp.gameObject.SetActive(false);
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }
    private void Update()
    {
        if (playerLife <= 0)
        {
            EndGamePopUp.gameObject.SetActive(true);
            OnLoose?.Invoke();
        }
    }
    public void WinCondition()
    {
        EndGamePopUp.gameObject.SetActive(true);
        OnWin?.Invoke();
    }
    public void GainCoin()
    {
        playerCoins = playerCoins + 1;
        OnCoinsUpdate?.Invoke(playerCoins);
    }
    public void ModifyLife(int amount)
    {
        playerLife = playerLife + amount;
        if (playerLife > 10)
        {
            playerLife = 10;
        }
        OnLifeUpdate?.Invoke(playerLife);
    }
    private void OnEnable()
    {
        Coin.OnPlayerCollider += GainCoin;
        Healt.OnPlayerCollider += ModifyLife;
    }
    private void OnDisable()
    {
        Coin.OnPlayerCollider -= GainCoin;
        Healt.OnPlayerCollider -= ModifyLife;
    }
}
