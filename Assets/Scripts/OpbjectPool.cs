using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpbjectPool : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField] [Range(0,50)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)]float spawnTimer = 1f;

    GameObject[] pool;

    void Awake()
    {
        InicializeArray();
    } 

    void Start()
    {
        StartCoroutine("InstatiatingEnemy");
    }

    void InicializeArray()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }

    }

    void EnableObjectInPool()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy != true)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator InstatiatingEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
