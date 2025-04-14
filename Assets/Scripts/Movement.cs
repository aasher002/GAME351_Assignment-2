using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float moveSpeed = 30f;
    public float turnSpeed = 60f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Terrain terrain = Terrain.activeTerrain;

        Vector3 position = transform.position;

        // set the game object's translation (not an increment)
        transform.position = position;


        if (Input.GetKey(KeyCode.W)) {
            // increment the game object's translation
            rb.transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.S)) {
            rb.transform.Translate(new Vector3(0, 0, -moveSpeed * Time.deltaTime));
        }
        
        if (Input.GetKey(KeyCode.A)) {
            rb.transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.D)) {
            rb.transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }
    }
}