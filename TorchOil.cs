using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchOil : MonoBehaviour
{
    public float refillAmount = 30f;
    public AudioClip refillSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Torch torch = other.GetComponent<Torch>();

            if (torch != null)
            {
                torch.AddDuration(refillAmount);
                AudioSource.PlayClipAtPoint(refillSound, transform.position);
                Destroy(gameObject);
            }
        }
    }
}