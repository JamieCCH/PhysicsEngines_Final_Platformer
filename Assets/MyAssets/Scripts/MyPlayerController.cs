using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LaunchProjectile))]

public class MyPlayerController : MonoBehaviour {
  
    LaunchProjectile m_projectile = null;

    public GameObject winScreen;
    public GameObject dieScreen;
    private Transform m_currMovingPlatform = null;

    void Start () {
        m_projectile = GetComponent<LaunchProjectile>();
    }

	void Update () {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "dieArea")
        {
            dieScreen.SetActive(true);
        }
    }

    private void OnCollisionStay(Collision collision){

        if(collision.gameObject.name == "Pressure_plate_Button")
        {
            StartCoroutine(WaitAndFly(2.5f));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MovingFloor")
        {
            m_currMovingPlatform = collision.gameObject.transform;
            transform.SetParent(m_currMovingPlatform);
        }

        if (collision.gameObject.name == "RotatingTrap" || collision.gameObject.tag == "Projectile")

        {
            dieScreen.SetActive(true);
        }

        if (collision.gameObject.name == "RollerBall")
        {
            winScreen.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.tag == "MovingSurfaceCollider")
            m_currMovingPlatform = null;
    }

    private IEnumerator WaitAndFly(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        m_projectile.Launch();
    }

}
