using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 8.5f;

    //Velocity to store our speed going down
    Vector3 velocity;
    //Gravity variable
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //Ground Check Variable
    public Transform groundCheck;
    public float groundDistance = 1.48f;
    public LayerMask groundMask; // <-- What objects the sphere we create should check for
    bool isGrounded; //Boolean for if the player is on the ground

    // Player health variables
    public float maxHealth = 100f; // maximum health
    public float currentHealth; // current health
    public Slider healthSlider; // reference to the health slider UI element

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // set current health to max health
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        //Physics of free fall
        controller.Move(velocity * Time.deltaTime);
    }

    // Function to decrease the player's health and update the Slider
    public void TakeDamage(float damage)
{
    // calculate the percentage of damage taken
    float damageTaken = damage / maxHealth;
    // decrease the currentHealth value by the percentage of damage taken
    currentHealth -= currentHealth * damageTaken;
    // update the health slider value
    healthSlider.value = currentHealth / maxHealth;
}

}
