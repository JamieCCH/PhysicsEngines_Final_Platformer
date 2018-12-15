using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour {

    Vector3 spawnPosition = Vector3.zero;
    float destroyTime = 1.5f;
    Rigidbody m_rb = null;

    void Start()
    {
        m_rb = gameObject.GetComponent<Rigidbody>();
        m_rb.isKinematic = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("hit");

            StartCoroutine(Falling(2.5f));

        }
    }


    private IEnumerator Falling(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        m_rb.useGravity = true;
        m_rb.isKinematic = false;
    }

    void Update () {
		
	}
}
