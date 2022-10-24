using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalFall : MonoBehaviour
{
    public MovePlayer movePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("Floor"))
            movePlayer.jumpAllowed = true;
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Floor"))
            movePlayer.jumpAllowed = false;
    }
}
