using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    public GameObject playerObj;
    public FirstPersonController MovementScript;
    public bool isRed;
    public DieScript diescript;
    public GameObject redSkin;
    public GameObject blueSkin;
    public bool teamSet = false;
    public GameObject playerNameTextObj;
    public GameObject floatingInfo;
    public string playerName;
    public GameObject nameInput;
    public bool nameSet = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("playermanager initialised");
        redSkin.SetActive(false);
        blueSkin.SetActive(false);
        MovementScript = playerObj.GetComponent<FirstPersonController>();
        diescript = playerObj.GetComponent<DieScript>();
        Debug.Log("playermanager-all vars initialised");
        if(!nameSet){
            Cursor.lockState = CursorLockMode.Confined;
            nameSet=true;
        }
    }

    public void OnTriggerEnter(Collider other){
        if(!teamSet){
            if(other.tag == "respawnblue") {
                isRed = false;
            } else if (other.tag == "respawnred") {
               isRed = true;
            }

            if(isRed){
               redSkin.SetActive(true);
            }else if(!isRed){
                blueSkin.SetActive(true);
            }
            teamSet = true;
        }
    }

    public void setName(string newPlayerName){
        playerName = newPlayerName;
        playerNameTextObj.GetComponent<TextMeshPro>().text = playerName;
        nameInput.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}