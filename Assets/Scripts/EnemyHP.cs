using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{   
    [SerializeField] int maxHP = 4;
    [SerializeField] int difficultyUp = 1;
    int currentHP;

    Enemy enemy;
    void OnEnable()
    {
        currentHP = maxHP;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHP --;
        if (currentHP <= 0)
        {
            gameObject.SetActive(false);
            maxHP += Mathf.Abs(difficultyUp);
            enemy.RewardGold();
        }
    }
}
