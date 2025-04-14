using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    public float cameraHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Terrain terrain = Terrain.activeTerrain;
        Vector3 position = transform.position;

        position.y = terrain.SampleHeight(position);
        position.y += cameraHeight;
        
        transform.position = position;
    }
}
