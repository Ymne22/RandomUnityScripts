using UnityEngine;

public class Medikit : MonoBehaviour
{
    public int healingAmount = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healingAmount);
                Destroy(gameObject);
            }
        }
    }
}