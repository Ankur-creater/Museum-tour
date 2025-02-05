using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float movementSpeed = 5f;
    public float rotationSpeed = 100f;

    void Start()
    {
        // Check if CharacterController is attached
        if (characterController == null)
        {
            characterController = GetComponent<CharacterController>();
            if (characterController == null)
            {
                Debug.LogError("CharacterController component is missing. Please add it to the GameObject.");
            }
        }
    }

    void Update()
    {
        // Call movement and rotation methods
        Move();
        Rotate();
    }

    void Move()
    {
        // Get input from keyboard (WASD or arrow keys)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate direction based on input
        Vector3 moveDirection = (transform.forward * vertical + transform.right * horizontal).normalized;

        // Move the character
        characterController.Move(moveDirection * movementSpeed * Time.deltaTime);
    }

    void Rotate()
    {
        // Get horizontal mouse movement
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        // Rotate the player around the y-axis
        transform.Rotate(0, mouseX, 0);
    }
}
