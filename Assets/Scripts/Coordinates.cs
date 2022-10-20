using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class Coordinates : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray; 
    TextMeshPro label;
    Vector2Int coordinate = new Vector2Int();
    Waypoint waypoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateParentName();
        }
        ColorCoordinates();
        ToggleLabels();
    }

    void ColorCoordinates()
    {
        if(waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }

    }
    

    private void UpdateParentName()
    {
        transform.parent.name = coordinate.ToString();
    }

    private void DisplayCoordinates()
    {
        coordinate.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinate.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = ($"{coordinate.x},{coordinate.y}");
    }
}
