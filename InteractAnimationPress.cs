using UnityEngine;

public class InteractAnimationPress : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    private Animator animator;
    private bool isPlayerInRange;

    private void Start()
    {
        // Disable the Animator component at the start
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Set the player in range flag to true
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Set the player in range flag to false
            isPlayerInRange = false;
        }
    }

    private void Update()
    {
        // Check if the player is in range and has pressed the interact key
        if (isPlayerInRange && Input.GetKeyDown(interactKey))
        {
            // Enable the Animator component to play the animation
            animator.enabled = true;
        }
    }
}