using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

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
        if (BuildMode.instance.currentItem.name != "") return;

        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (UICheck.IsPointerOverUIObject()) { return; }
            _agent.SetDestination(hit.point);
            Instantiate(point, hit.point, Quaternion.identity);
        }
    }
}

public class UICheck
{
    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new(EventSystem.current)
        {
            position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
        };

        List<RaycastResult> results = new();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
