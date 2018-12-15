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
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("hit");
            //m_rb.useGravity = true;

            StartCoroutine(Falling(0.3f));
        }
    }


    private IEnumerator Falling(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        m_rb.isKinematic = false;
    }

    void Update () {
		
	}
}
