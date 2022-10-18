using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public GameObject tower;
    [SerializeField] bool isPlaceble;
    void OnMouseDown()
    {
        if (isPlaceble)
        {
            Instantiate(tower, transform.position, Quaternion.identity);
            isPlaceble = false;
        }
    }
}
