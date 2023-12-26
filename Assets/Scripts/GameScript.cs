using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] private Transform emptySpace = null;
    private Camera _camera;
    private float _approx = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if you did input
        if(Input.GetMouseButton(0))
        {
            // Projecting raycast from camera to mouse position (in camera prespective)
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            // Projecting from the HIT with origin dot with a direction
            RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction);

           
            // Check if hit == true
            if (hit)
            {
                // it will check if distance between emptyspace and the hit lesser than approximative move
                //if (true) then it will change the emptyspace position with hit and the hit will take last empty

                if (Vector2.Distance(emptySpace.position, hit.transform.position) < _approx)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    emptySpace.position = hit.transform.position;
                    hit.transform.position = lastEmptySpacePosition;
                }
            }
        }
    }
}
