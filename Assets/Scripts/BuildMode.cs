using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BuildMode : MonoBehaviour
{
    private Camera _camera;
    public GameObject stopbutton;
    public static BuildMode instance;

    public Item currentItem = null;

    void Start()
    {
        instance = this;

        _camera = Camera.main;
        if (_camera == null)
        {
            Debug.LogError("The Camera is null on the player controller.");
        }

        stopbutton.SetActive(false);

    }

    //Wanneer een item is gekozen, zet het gekozen item en zet de 'stop buildmode' button actief
    public void EnterBuildMode(Item item)
    {

        Debug.Log("Build Mode Actief");
        currentItem = item;
        stopbutton.SetActive(true);

    }

    //Wanneer een item is gekozen, check of de muisknop word ingedrukt
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentItem != null && !UICheck.IsPointerOverUIObject())
        {
            //Als de muisknop is ingedrukt, check hvl coins de player heeft en of de player dus het item kan betalen
            if (currentItem.price <= PlayerData.instance.coins)
            {
                PlayerData.instance.coins -= currentItem.price;
            }
            else
            {
                Debug.Log("Niet genoeg coins");
                return;
            }

            //Plaats het item waar de player klikt
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Instantiate(currentItem.prefab, hit.point, Quaternion.identity);
            }

        }
    }

    //Wanneer de buildmode uit gaat, zet het huidige item naar null en haal de stopbutton weg
    public void StopBuildMode()
    {
        currentItem = null;
        stopbutton.SetActive(false);
    }
}
