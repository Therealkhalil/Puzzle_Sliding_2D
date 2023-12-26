using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Overlays;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    [SerializeField] private BlockDetection blockDetection;
    [SerializeField] private LayerMask moveableLayerMask;

    private int direction = 1; // direction of enemy (on x axis)


    //the raycasts
    private RaycastHit2D rightLedgeRayCastHit;
    private RaycastHit2D leftLedgeRayCastHit;
    private RaycastHit2D rightWallRayCastHit;
    private RaycastHit2D leftWallRayCastHit;

    [Header("RayCasts")]
    [SerializeField] private Vector2 rayCastOffset; // center of the raycast where it will be placed
    [SerializeField] private float rayCastLengthDown, rayCastLengthSide = 2; // length of the raycast
    [SerializeField] private LayerMask rayCastLayerMask; // the layers that will interact with it.
    private Vector2 targetVelocity;

    // Update is called once per frame
    void Update()
    {
        if (blockDetection.lastClickedBlock != null) // Check if a block was clicked
        {
            if (IsBlockMovable(blockDetection.lastClickedBlock, out Vector2 moveDirection)) // Check move permissions and get direction
            {
                // Move the last clicked block in the determined direction
                blockDetection.lastClickedBlock.transform.Translate(moveDirection);
                blockDetection.lastClickedBlock = null; // Reset for next click
            }
        }
        

        
    }

    bool IsBlockMovable(GameObject block, out Vector2 moveDirection)
    {
        moveDirection = Vector2.zero;
        float detectionDistance = 10.0f; // Set this to the appropriate distance for your game

        // Check all four directions: up, down, left, right
        Vector2[] directions = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

        foreach (Vector2 direction in directions)
        {
            RaycastHit2D hit = Physics2D.Raycast(block.transform.position, direction, detectionDistance, moveableLayerMask);

            if (hit.collider == null) // If no collider was hit by the raycast, that means the block can move in this direction
            {
                moveDirection = direction;
                return true;
            }
        }

        // If none of the directions were valid, return false
        return false;
    }

}
