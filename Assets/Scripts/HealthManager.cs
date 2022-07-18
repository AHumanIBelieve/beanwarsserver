using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class HealthManager : NetworkBehaviour
{
    public float health = 10;
    public GameObject PlayerObj;
    public DieScript diescript;
    
    // Start is called before the first frame update
    void Start()
    {
        diescript = PlayerObj.GetComponent<DieScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            diescript.die();
        }
    }
}
