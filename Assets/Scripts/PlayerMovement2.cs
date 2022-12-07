using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{ 
   [SerializeField] private bool gameOver;
   public float speed;
   //public float rotationSpeed;
   public float jumpSpeed;
   public Transform cam; 
   public float turnSmoothTime = 0.3f;
   public AudioClip stepSfx;

   private CharacterController controller;
   private Animator anim;
   private float ySpeed;
   private float originalStepOffset;
   float turnSmoothVelocity = 0.0f;
   private Vector3 moveDirection;
   private AudioSource audioSource;
   private BoxCollider sword;

   public List<DialogService.MessageInfo> messages = new List<DialogService.MessageInfo>();

   private void Awake()
   {
    DialogService.Instance.ShowDialogs(messages);
   }

   void Start() {
        gameOver = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        originalStepOffset = controller.stepOffset;
        audioSource = GetComponent<AudioSource>();
        sword = GameObject.Find("OHS03Polyart").GetComponent<BoxCollider>();
   }

    void Update() {
            if(!gameOver){
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            bool attack = Input.GetKey(KeyCode.Mouse0);

            Vector3 movementDirection = new Vector3(horizontal, 0, vertical);    
            float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
            movementDirection.Normalize();

            if(magnitude > 0)
            {
                float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle.eulerAngles.y, ref turnSmoothVelocity, turnSmoothTime);
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, cam.eulerAngles.y, ref turnSmoothVelocity, turnSmoothTime);
                //Debug.Log("angle: " + cam);
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

            if(attack)
                FindObjectOfType<AudioManager>().Play("SwordSwing");
            anim.SetFloat("moveX", horizontal);
            anim.SetFloat("moveY", vertical);
            anim.SetFloat("velocityY", velocity.y);
            anim.SetBool("attack", attack);
        }
    }

    private void Step() {
         audioSource.PlayOneShot(stepSfx);
    }
}
