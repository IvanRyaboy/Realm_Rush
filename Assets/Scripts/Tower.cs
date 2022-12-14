using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int towerCost = 75;
    [SerializeField] int towerDamage;

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if(bank == null)
        {
            return false;
        }
        if(bank.CurrentBalance >= towerCost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdrawals(towerCost);
            return true;
        }
        return false;
    }

    public int ReturnDamage()
    {
        return towerDamage;
    }

    public void UpdateDamage()
    {
        towerDamage ++;
    }
}
