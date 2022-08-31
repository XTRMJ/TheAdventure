using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Animator anim;
    public GameObject body;
    public float turnSpeed;
    public float forward,side,forceJump = 8f;
    public bool jumpAllowed;
    public Rigidbody rb;
    public BoxCollider colBase,colFloor;
    // Start is called before the first frame update
    void Start()
    {
        jumpAllowed = false;
        anim = GetComponent<Animator>();
        colBase = colFloor = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        forward = Input.GetAxis("Vertical");
        side = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * forward * Time.deltaTime * 5);
        transform.Rotate(0, side * Time.deltaTime * turnSpeed, 0);
        anim.SetFloat("moveX",side);
        anim.SetFloat("moveY",forward);
        colBase.transform.position = body.transform.position;
        Debug.Log(colBase.transform.position.y);
        Debug.Log(body.transform.position.y);
        if(jumpAllowed){
            if(Input.GetKeyDown(KeyCode.Space)){
                anim.SetBool("jump",true);
                rb.AddForce(new Vector3(0, forceJump, 0), ForceMode.Impulse);
                //colBase.
            }
            anim.SetBool("finishJump",true);
        }else{
            anim.SetBool("jump",false);
            anim.SetBool("finishJump",false);
        }
    }

    private void LateUpdate() {
        if(transform.position.y < 99){
            transform.position = new Vector3(transform.position.x,105,transform.position.z);
        }
    }
}
