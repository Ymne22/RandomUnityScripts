using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    private Animator animator;

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
            // Enable the Animator component when the player enters the trigger
            animator.enabled = true;
        }
    }
}