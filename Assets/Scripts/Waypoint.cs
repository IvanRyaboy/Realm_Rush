using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public GameObject tower;
    [SerializeField] bool isPlaceble;

    public bool IsPlaceable { get { return isPlaceble; } }

    void OnMouseDown()
    {
        if (isPlaceble)
        {
            Instantiate(tower, transform.position, Quaternion.identity);
            isPlaceble = false;
        }
    }
}
