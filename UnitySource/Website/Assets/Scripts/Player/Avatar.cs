using UnityEngine;

public class Avatar : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 3f;
    public float gravityForce = -9.81f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    public LayerMask groundMask;


    CharacterController cc;
    bool isGrounded = true;

    Vector3 velocity;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);
        Movement();
        Gravity();
    }

    void Movement()
    {
        //walking
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = transform.right * horizontal + transform.forward * vertical;

        //walking
        if(direction.magnitude > 0)
        {
            cc.Move(direction.normalized * speed * Time.deltaTime);
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", false);
        }
        
        //jumping
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityForce);
        }

        //sprinting
        if(Input.GetKey(KeyCode.LeftShift))
        {
            cc.Move(direction.normalized * speed * Time.deltaTime);
            GetComponent<Animator>().SetBool("isRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isRunning", false);
        }
    }
    void Gravity()
    {
        if(isGrounded && velocity.y < -2f)
        {
            velocity.y = -2f;
        }

        velocity.y += gravityForce * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
    }
}
