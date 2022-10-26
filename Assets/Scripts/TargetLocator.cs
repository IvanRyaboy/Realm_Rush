using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float range = 15f;
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem bolt;
    private bool activeParticle;

    // Update is called once per frame
    void Update()
    {
        FindClosetTarget();
        AimWeapon();
        Attack(activeParticle);
    }

    void FindClosetTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;
        
        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    void AimWeapon() 
    {
        float enemyDistance = Vector3.Distance(transform.position, target.transform.position);
        if(enemyDistance > range)
            activeParticle = false;
        else
            activeParticle = true;
        weapon.LookAt(target);
    }

    void Attack(bool isActive)
    {
        if (isActive == true)
        {
            bolt.Play();
        }
        else
        {
            bolt.Pause();
        }
    }

}
