using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DieScript : NetworkBehaviour
{
    public GameObject playerObj;
    public GameObject deadScreen;
    public FirstPersonController MovementScript;
    public GameObject respawnPosRed;
    public GameObject respawnPosBlue;
    public GameObject respawnPos;
    public bool isDead = false;
    public PlayerManager playermanager;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("diescript instialised");
        respawnPosRed = GameObject.Find("respawnpointred");
        respawnPosBlue = GameObject.Find("respawnpointblue");
        deadScreen.SetActive(false);
        MovementScript = playerObj.GetComponent<FirstPersonController>();
        playermanager = playerObj.GetComponent<PlayerManager>();
        Debug.Log("diescript-all vars initialised");
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead){
            if(Input.GetKeyDown(KeyCode.R)){
                respawn();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "deathzone"){
            die();
        }else if(other.tag == "respawnblue"){
            respawnPos = respawnPosBlue;
        }else if(other.tag == "respawnred"){
            respawnPos = respawnPosRed;
        }
    }

    public void respawn(){
        playerObj.transform.position = new Vector3(respawnPos.transform.position.x, respawnPos.transform.position.y, respawnPos.transform.position.z);
        MovementScript.cameraCanMove = true;
        deadScreen.SetActive(false);
    }

    public void die(){
        isDead = true;
        MovementScript.cameraCanMove = false;
        print("mesa dead");
        deadScreen.SetActive(true);
    }
}
