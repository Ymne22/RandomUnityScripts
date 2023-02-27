using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPlayer : MonoBehaviour
{
    public float openAngle = 90f;  // The angle the door should open
    public float openSpeed = 2f;   // The speed at which the door opens
    public AudioClip openSound;   // The sound the door makes when it opens
    public AudioClip closeSound;  // The sound the door makes when it closes
    public bool isOpen = false;   // Whether the door is open or not
    private Vector3 closedPosition;  // The position of the door when it's closed
    private Quaternion closedRotation;  // The rotation of the door when it's closed
    private Vector3 openPosition;  // The position of the door when it's open
    private Quaternion openRotation;  // The rotation of the door when it's open
    private AudioSource audioSource;   // The audio source component on the door

    // Start is called before the first frame update
    void Start()
    {
        // Set the closed position and rotation to the current position and rotation of the door
        closedPosition = transform.position;
        closedRotation = transform.rotation;

        // Calculate the open position and rotation based on the open angle
        float radians = Mathf.Deg2Rad * openAngle;
        float x = Mathf.Sin(radians) * transform.localScale.x / 2;
        float z = Mathf.Cos(radians) * transform.localScale.x / 2;
        openPosition = closedPosition + transform.right * x + transform.forward * z;
        openRotation = Quaternion.Euler(closedRotation.eulerAngles + new Vector3(0f, openAngle, 0f));

        audioSource = GetComponent<AudioSource>();  // Get the audio source component on start
    }

    // Update is called once per frame
    void Update()
    {
        // If the door is open, move it towards the open position and rotate it towards the open rotation
        if (isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, openPosition, openSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, openRotation, openSpeed * Time.deltaTime);
        }
        // If the door is closed, move it towards the closed position and rotate it towards the closed rotation
        else
        {
            transform.position = Vector3.Lerp(transform.position, closedPosition, openSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, closedRotation, openSpeed * Time.deltaTime);
        }
    }

    // OnTriggerEnter is called when a collider enters the trigger zone of the door
    void OnTriggerEnter(Collider other)
    {
        // If the collider has the "Player" tag and the door is closed, open the door
        if (other.CompareTag("Player") && !isOpen)
        {
            isOpen = true;  // Set the door to open
            audioSource.clip = openSound;  // Set the audio clip to the open sound
            audioSource.Play();  // Play the open sound
        }
    }

    // OnTriggerExit is called when a collider exits the trigger zone of the door
    void OnTriggerExit(Collider other)
    {
        // If the collider has the "Player" tag and the door is open, close the door
        if (other.CompareTag("Player") && isOpen)
        {
            isOpen = false;  // Set the door to closed
            audioSource.clip = closeSound;  // Set the audio clip to the close sound
            audioSource.Play();  // Play the close sound
        }
    }
}