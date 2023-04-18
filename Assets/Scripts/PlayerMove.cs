using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public GameObject point;
    private Camera _camera;
    private NavMeshAgent _agent;
    
    // Start is called before the first frame update
    void Start()
    {
        
        _camera = Camera.main;
        if(_camera == null)
        {
            Debug.LogError("The Camera is null on the player controller.");

        }
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        
    }
    private void HandleMovement()
    {
        if (!Input.GetMouseButton(0)) return;

        RaycastHit hit;
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit))
        {
            _agent.destination = hit.point;
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse clicked");

            if (Physics.Raycast(ray, out hit))
            {
                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(point, hit.point, Quaternion.identity);
                    print("My object is clicked by mouse");
                    
                }
            }
            print("click");
        }
    }
    
    
        
    
}
