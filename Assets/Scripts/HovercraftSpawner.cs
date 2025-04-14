using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HovercraftSpawner : MonoBehaviour
{
    public GameObject hovercraft1Prefab;
    public GameObject hovercraft2Prefab;
    public GameObject hovercraft3Prefab;

    public Terrain terrain;

    private List<GameObject> spawnedHovercrafts = new List<GameObject>();
    private int max = 10;
    private float minSpacing = 5f;

    void Update()
    {
        if (spawnedHovercrafts.Count >= max)
            return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            Spawn(hovercraft1Prefab);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Spawn(hovercraft2Prefab);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Spawn(hovercraft3Prefab);
    }

    void Spawn(GameObject prefab)
    {
        Vector3 spawnPos = GetValidSpawnPosition();
        if (spawnPos != Vector3.zero)
        {
            GameObject newCraft = Instantiate(prefab, spawnPos, Quaternion.identity);
            spawnedHovercrafts.Add(newCraft);
        }
    }

    Vector3 GetValidSpawnPosition()
    {
        for (int i = 0; i < 20; i++)
        {
            float x = Random.Range(terrain.transform.position.x, terrain.terrainData.size.x);
            float z = Random.Range(terrain.transform.position.z, terrain.terrainData.size.z);
            float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrain.transform.position.y;

            Vector3 candidatePos = new Vector3(x, y, z);

            bool tooClose = false;
            foreach (GameObject craft in spawnedHovercrafts)
            {
                if (Vector3.Distance(candidatePos, craft.transform.position) < minSpacing)
                {
                    tooClose = true;
                    break;
                }
            }

            if (!tooClose)
                return candidatePos;
        }

        return Vector3.zero; 
    }
}
