using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LaunchProjectile))]

public class MyPlayerController : MonoBehaviour {
  
    LaunchProjectile m_projectile = null;

    public GameObject winScreen;
    public GameObject dieScreen;

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
        //Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Pressure_plate_Button")
        {
            StartCoroutine(WaitAndFly(2.5f));
        }

        if (collision.gameObject.name == "RollerBall")
        {
            winScreen.SetActive(true);
        }


    }

    private IEnumerator WaitAndFly(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        m_projectile.Launch();
    }

}
