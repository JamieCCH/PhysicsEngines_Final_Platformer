using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTrap : MonoBehaviour {

    [SerializeField] private float spinSpeed = 80f;

    // Use this for initialization
    void Start () {

    }

    void Rotating()
    {
        transform.Rotate(spinSpeed * Time.deltaTime, 0, 0);
    }

    // Update is called once per frame
    void Update () {
        Rotating();
    }
}
