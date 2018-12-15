using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]

public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform target;

    [SerializeField] private float distance = 3.0f;
    [SerializeField] private float height = 2.0f;
    [SerializeField] private float rotationDamping = 1.5f;
    [SerializeField] private float heightDamping;

    public Vector3 offset = new Vector3(0f, 1.5f, -2.0f);

    private Rigidbody m_rb = null;
    private float targetHead = .2f;

    // Use this for initialization
    void Start () {
        m_rb = GetComponent<Rigidbody>();
        //targetHead = transform.position.y + .2f;
    }

    private void LateUpdate()
    {

        transform.position = target.position + offset;

        var wantedRotationAngle = target.eulerAngles.y;
        var wantedHeight = target.position.y; //+ height;

        var currentRotationAngle = transform.eulerAngles.y;
        var currentHeight = transform.position.y;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        transform.LookAt(new Vector3(target.position.x, transform.position.y - targetHead,target.position.z));
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.name);
    //}

}
