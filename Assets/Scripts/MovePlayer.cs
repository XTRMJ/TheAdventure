using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    //GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float forward = Input.GetAxis("Vertical");
        float side = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * forward * Time.deltaTime * 20);
        transform.Translate(Vector3.right * side * Time.deltaTime * 20);
    }
}
