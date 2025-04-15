using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public float hoverHeight = 2f;
    public float hoverForce = 100f;
    public float idleWobbleAmount = 0.1f;
    public float hoverDamping = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            rb.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }

        if (rb.velocity.magnitude < 0.1f)
        {
            rb.AddTorque(Random.insideUnitSphere * idleWobbleAmount);
        }

        if (rb.velocity.y > 0)
        {
            rb.AddForce(Vector3.down * hoverDamping, ForceMode.Acceleration);
        }
    }
}
