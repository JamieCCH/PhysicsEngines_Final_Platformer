using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIProjectile : MonoBehaviour {

   
    public float speed = 2.5f;
    public float rangeToPlayer;
    public Transform spawnPoint;
    public GameObject projectilePrefab;
    private GameObject Player;
    private bool firing;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindWithTag("Player");
    }

    private IEnumerator Shoot(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //rb.velocity = Player.transform.position * 3.5f;

        GameObject p = Instantiate(projectilePrefab, Player.transform.position, Quaternion.identity);
        p.GetComponent<Rigidbody>().velocity = Vector3.up * speed;

    }

    bool PlayerInRange()
    {
        return (Vector3.Distance(Player.transform.position, transform.position) <= rangeToPlayer);
    }


    // Update is called once per frame
    void Update () {

        //if (PlayerInRange()){
        //    //transform.LookAt(Player.transform.position);
        //    Vector3 direction = (gameObject.transform.position - Player.transform.position).normalized;
        //    gameObject.transform.rotation = Quaternion.LookRotation(direction);
        //    StartCoroutine(Shoot(3.5f));
        //}

        transform.LookAt(Player.transform.position);
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.5f, transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.transform.gameObject.tag == "Player")
            {
                if (firing == false)
                {
                    firing = true;
                    gameObject.transform.rotation = Quaternion.LookRotation(Player.transform.position - transform.position);
                    StartCoroutine(Shoot(3.5f));
                }
            }
        }
    }


}
