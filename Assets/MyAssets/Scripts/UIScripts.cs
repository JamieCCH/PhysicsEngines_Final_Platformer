using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScripts : MonoBehaviour {

    public Button replayBtnInWin;
    public Button replayBtnInLose;
    private GameObject player;
    public Transform spawnPoint;
    public GameObject winScreen;
    public GameObject dieScreen;

    void Replay()
    {
        //reset ball's position
        player.transform.position = spawnPoint.position;

        winScreen.SetActive(false);
       
        dieScreen.SetActive(false);

    }

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player");
        replayBtnInWin.onClick.AddListener(Replay);
        replayBtnInLose.onClick.AddListener(Replay);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
