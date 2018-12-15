using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LaunchProjectile))]

public class AIProjectile : MonoBehaviour {

    public float rangeToPlayer;
    public Transform spawnPoint;
    private GameObject Player;


    LaunchProjectile m_projectile = null;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindWithTag("Player");
        m_projectile = GetComponent<LaunchProjectile>();
    }
	
	// Update is called once per frame
	void Update () {

        if (PlayerInRange()){
            m_projectile.Launch();
        }

    }

    bool PlayerInRange()
    {
        return (Vector3.Distance(Player.transform.position, transform.position) <= rangeToPlayer);
    }
}
