using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{ 
   public float speed;
   public float rotationSpeed;
   public float jumpSpeed;
   public Transform cam; 
   public float turnSmoothTime = 0.1f;

   private CharacterController controller;
   private Animator anim;
   private float ySpeed;
   private float originalStepOffset;
   float turnSmoothVelocity;
   private Vector3 moveDirection;

   void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        originalStepOffset = controller.stepOffset;
   }

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontal, 0, vertical);    
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        if(magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if(controller.isGrounded) {
            controller.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            if(Input.GetKey(KeyCode.Space)) {
                ySpeed = jumpSpeed;
                anim.SetTrigger("jump");
            }
        } else {
            controller.stepOffset = 0;
        }
        
        Vector3 velocity = moveDirection * magnitude;
        velocity.y = ySpeed;
        controller.Move(velocity * Time.deltaTime);
/*
        if(movementDirection != Vector3.zero) {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }*/
        anim.SetFloat("moveX", vertical);
        anim.SetFloat("moveY", horizontal);
        anim.SetFloat("velocityY", velocity.y);


    }
}
