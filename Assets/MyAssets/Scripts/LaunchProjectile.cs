using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class LaunchProjectile : MonoBehaviour {

    public Transform m_desiredDestination = null;
    public GameObject projectilePrefab;

    private Rigidbody m_rb = null;
    private bool m_isGrounded = true;

    public bool IsGrounded
    {
        get { return m_isGrounded; }
    }

    private float verticalAngle = 50.0f;
    private float horizontalAngle = 5.0f;
    private float initialVelocity = 3.0f;
    private float inputForce = 15.0f;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    public void Launch()
    {
        if (!IsGrounded)
        {
            return;
        }

        m_isGrounded = false;
        m_rb.GetComponent<Rigidbody>().velocity = GetLandingPosition() * inputForce;

    }

    Vector3 GetLandingPosition()
    {
        float vertAngleRad = Mathf.Deg2Rad * verticalAngle;
        float hozAngleRad = Mathf.Deg2Rad * horizontalAngle;
        float dh = ((-2 * initialVelocity * initialVelocity * Mathf.Sin(vertAngleRad) * Mathf.Cos(vertAngleRad)) / Physics.gravity.y);

        Vector3 landingPosition = new Vector3(Mathf.Sin(hozAngleRad), Mathf.Sin(vertAngleRad), Mathf.Cos(hozAngleRad));

        return landingPosition;
    }

}
