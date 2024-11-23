using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 3.0f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    private Vector3 lastPosition = new Vector3(0, 0, 0);
    private CharacterController controller;

    bool isMoving;
    public int health = 100;
    public SpawnManager spawnManager;
    public float knockbackDuration = 0.5f; // Duration of the knockback effect
    public float knockbackForce = 5f;      // Strength of the knockback
    private Vector3 knockbackDirection;
    private float knockbackTimer;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private IEnumerator WaitForSecondsCoroutine()
    {
        yield return new WaitForSeconds(1f); // Adjust the wait time as needed
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }
    void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (controller && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        move.y = 0;
        if (controller)
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        lastPosition = gameObject.transform.position;
    }
    public void Damage()
    {

        health = health - 10;
        if (health <= 0)
        {
            //Debug.Log("Player has died");
            Debug.Log("Player hp" + health);
        }
        // Debug.Log("Player has been damaged");
    }
    public void Knockback()
    {
        knockbackDirection = (transform.position - this.transform.position).normalized;

        // Set the knockback timer
        knockbackTimer = knockbackDuration;
        if (knockbackTimer > 0)
        {
            // Decrease the timer
            knockbackTimer -= Time.deltaTime;

            // Move the CharacterController in the knockback direction
            controller.Move(knockbackDirection * knockbackForce * Time.deltaTime);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.gameObject.tag == "Enemy")
        {

            Debug.Log("Player hp" + health);
            Destroy(hit.gameObject);
            //Debug.Log("Collision detected" + hit.gameObject.tag);
            Damage();
            
        }
        
    }
}