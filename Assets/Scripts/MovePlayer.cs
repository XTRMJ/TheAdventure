using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Animator anim;
    public float turnSpeed = 2.0f;
    public float forward,side,forceJump = 8.0f;
    public bool jumpAllowed;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        jumpAllowed = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        forward = Input.GetAxis("Vertical");
        side = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * forward * Time.deltaTime * 5);
        transform.Rotate(0,side * Time.deltaTime * turnSpeed,0);
        anim.SetFloat("moveX",side);
        anim.SetFloat("moveY",forward);
        if(jumpAllowed){
            if(Input.GetKeyDown(KeyCode.Space)){
                anim.SetBool("jump",true);
                rb.AddForce(new Vector3(0, forceJump, 0), ForceMode.Impulse);
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
