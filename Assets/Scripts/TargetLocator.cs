using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    GameObject enemy;
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem bolt;
    // Start is called before the first frame update
    void Start()
    {   
        enemy = GameObject.FindWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        RotateWeapon();
    }

    private void RotateWeapon()
    {
        try
        {
            weapon.LookAt(enemy.transform);
        }
        catch
        {
            Debug.Log("Kill");
            bolt.Pause();
        }
    }
}
