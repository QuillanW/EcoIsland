using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [HideInInspector]
    public Terrain terrain;

    public int coinsValue = 0;
    public int scoreValue = 0;

    private void Start()
    {
        StartCoroutine(MoveTowardsLand());
    }

    private IEnumerator MoveTowardsLand()
    {
        while (terrain.SampleHeight(transform.position) < 1.8f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new(0, 1.8f, 0), 1f * Time.deltaTime);
            yield return null;
        }
    }
}
