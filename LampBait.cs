using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampBait : MonoBehaviour
{
    public float baitDuration = 10f;
    public float baitRange = 10f;
    public AudioClip baitSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            MonsterAI monsterAI = other.GetComponent<MonsterAI>();

            if (monsterAI != null)
            {
                monsterAI.SetTarget(transform.position, baitDuration, baitRange);
                AudioSource.PlayClipAtPoint(baitSound, transform.position);
                Destroy(gameObject);
            }
        }
    }
}