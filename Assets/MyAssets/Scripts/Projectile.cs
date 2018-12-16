using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Transform spawnPoint;
    public GameObject projectilePrefab;
    private GameObject targetPlayer;
    private bool isFiring;

    [SerializeField] private float speed = 25f;

    void Start()
    {
        targetPlayer = GameObject.Find("Player");
    }

    private IEnumerator Shoot(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        isFiring = false;
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = (spawnPoint.transform.forward + Vector3.up / 10) * speed;

        Destroy(projectile.gameObject, 5);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            spawnPoint.LookAt(targetPlayer.transform);
            if (isFiring == false)
            {
                isFiring = true;
                StartCoroutine(Shoot(3.5f));
            }
        }
    }

}
