using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMode : MonoBehaviour
{
    public bool buildActive = false;
    
    private Camera _camera;

    public static BuildMode instance;

    void Start()
    {
        instance = this;

        _camera = Camera.main;
        if (_camera == null)
        {
            Debug.LogError("The Camera is null on the player controller.");
        }
        
        buildActive = true;
        
    }

    public void EnterBuildMode(Item item)
    {
        
        if(buildActive == true)
        {
            if (Input.GetMouseButtonDown(0))
            {

                var ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {


                    Instantiate(item.prefab, hit.point, Quaternion.identity);
                }

                Debug.Log("Build Mode Actief");
            }
        }
    }
    public void StopBuildMode()
    {
        if(buildActive == true)
        {
            buildActive = false;

        }
        else
        {
            Debug.Log("Already False");
        }
    }
}
