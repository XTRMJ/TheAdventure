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
        movePlayer.jumpAllowed = true;
    }
    private void OnTriggerExit(Collider other) {
        movePlayer.jumpAllowed = false;
    }
}
