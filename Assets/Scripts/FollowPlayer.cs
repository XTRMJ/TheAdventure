using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    //private Vector3 offset = new Vector3(0,3,-5);
    private float distance;
    private Vector2 sensitivity = new Vector2(1,1);
    private Vector2 angle = new Vector2(90 * Mathf.Deg2Rad,0);

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Update is called once per frame
    private void Update() {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");
        if(horizontal != 0){
            angle.x += horizontal * Mathf.Deg2Rad * sensitivity.x;
        }
        if(vertical != 0){
            angle.y += vertical * Mathf.Deg2Rad * sensitivity.y;
            angle.y = Mathf.Clamp(angle.y, -80 * Mathf.Deg2Rad, 80 * Mathf.Deg2Rad);
        }
    }

    // LastUpdate is called once per frame
    void LastUpdate()
    {
        Vector3 offset = new Vector3(
            Mathf.Cos(angle.x) *Mathf.Cos(angle.y),
            -Mathf.Sin(angle.y),
            -Mathf.Sin(angle.x) *Mathf.Cos(angle.y)
        );
        transform.position = player.transform.position + offset * distance;
        transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
    }
}
