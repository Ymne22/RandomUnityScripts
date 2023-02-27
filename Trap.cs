using UnityEngine;

public class Trap : MonoBehaviour
{
    public float monsterStunDuration = 5f;
    public float playerStunDuration = 3f;

    private void OnTriggerEnter(Collider other)
    {
        Monster monster = other.gameObject.GetComponent<Monster>();
        if (monster != null)
        {
            monster.Stun(monsterStunDuration);

            Destroy(gameObject);
        }

        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.Stun(playerStunDuration);

            Destroy(gameObject);
        }
    }
}