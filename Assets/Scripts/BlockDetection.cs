using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockDetection : MonoBehaviour
{
    /*
     if Objects on top of him == null then
     move top
     else if Objects on right of him == null then
     move right
     else if Objects on left of him == null then
     move left
     else if Objects on bottom of him == null then
     move bottom 
     else
     no move
     */

    [HideInInspector] public GameObject lastClickedBlock;  // Store reference to last clicked block

    void Update()
    {
        // Check for left mouse button clicks
        if (Input.GetMouseButtonDown(0))
        {
            // Get mouse position in world coordinates
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Perform actions based on mouse click, e.g., raycasting
            Debug.Log("clicked at: " + mouseWorldPos);
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log("Clicked on GameObject: " + hit.collider.gameObject.name);
                lastClickedBlock = hit.collider.gameObject;  // Store reference
            }
        }    
    }
}

