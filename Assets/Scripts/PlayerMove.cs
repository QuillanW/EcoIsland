using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public GameObject point;
    private Camera _camera;
    private NavMeshAgent _agent;
    
    void Start()
    {
        _camera = Camera.main;
        if(_camera == null)
        {
            Debug.LogError("The Camera is null on the player controller.");
        }
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            _agent.SetDestination(hit.point);
            Instantiate(point, hit.point, Quaternion.identity);
        }
    }
}
