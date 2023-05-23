using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public Transform player;

    public PlayerData playerData;

    public Transform garbageParent;

    private void Update()
    {
        foreach (Transform collectable in garbageParent)
        {
            if (Vector3.Distance(collectable.position, player.position) < 3f)
            {
                Collectable script = collectable.GetComponent<Collectable>();
                playerData.UpdateData(script.coinsValue, script.scoreValue);
                Destroy(collectable.gameObject);
            }
        }
    }
}
