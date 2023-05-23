using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainUtils;

public class GarbageSpawn : MonoBehaviour
{
    public Terrain terrain;

    public float spawnInterval = 1;
    public int maxSpawned = 25;

    public List<GameObject> garbageModels = new();

    private void OnEnable()
    {
        StartCoroutine(SpawnEveryInterval());
    }

    private IEnumerator SpawnEveryInterval()
    {
        if (transform.childCount < maxSpawned)
        {
            SpawnGarbage();
        }
        yield return new WaitForSeconds(spawnInterval);
        StartCoroutine(SpawnEveryInterval());
    }

    private void SpawnGarbage()
    {
        //Get a random position on the terrain
        Vector3 spawnPosition = terrain.transform.position + new Vector3(terrain.terrainData.size.x * Random.Range(0.1f, 0.9f), 0, terrain.terrainData.size.z * Random.Range(0.1f, 0.9f));
        //Check the height of the terrain at that location so it doesn't spawn below the ground
        float spawnHeight = Mathf.Max(1.8f, terrain.SampleHeight(spawnPosition));
        //Set the height of the spawn location to the new correct height
        spawnPosition = new Vector3(spawnPosition.x, spawnHeight, spawnPosition.z);

        //Get a random rotation (only on the y axis)
        Quaternion spawnRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

        //Choose a random model
        GameObject garbageModel = garbageModels[Random.Range(0, garbageModels.Count)];

        //Instatiate the model
        Instantiate(garbageModel, spawnPosition, spawnRotation, transform);
    }
}
