using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int bank = 150;
    [SerializeField] int currentBalance;

    public int CurrentBalance {get {return currentBalance; } }

    [SerializeField] TextMeshProUGUI displayBalance;

    void Awake()
    {
        currentBalance = bank;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdrawals(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        
        if (currentBalance < 0)
        {
            //lose the game
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        displayBalance.ClearMesh();
        displayBalance.text = "Gold: " + currentBalance.ToString();
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
