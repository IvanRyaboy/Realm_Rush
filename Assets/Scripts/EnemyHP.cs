using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{   
    [SerializeField] int maxHP;
    int currentHP;
    void Start()
    {
        currentHP = maxHP;
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHP--;
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
