using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public GameObject radarIndicatorPrefab;
    public float radarDuration = 3f;
    public float radarRange = 10f;
    private GameObject radarIndicator;
    private bool isRadarActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isRadarActive)
        {
            isRadarActive = true;
            StartCoroutine(ActivateRadar());
        }
    }

    IEnumerator ActivateRadar()
    {
        radarIndicator = Instantiate(radarIndicatorPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(radarDuration);

        Destroy(radarIndicator);
        isRadarActive = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (isRadarActive && other.CompareTag("Monster"))
        {
            Vector3 direction = other.transform.position - transform.position;
            float distance = direction.magnitude;

            if (distance <= radarRange)
            {
                Vector3 normalizedDirection = direction.normalized;
                Vector3 indicatorPosition = transform.position + normalizedDirection * distance;

                GameObject indicator = Instantiate(radarIndicatorPrefab, indicatorPosition, Quaternion.identity);
                indicator.transform.SetParent(radarIndicator.transform);
                indicator.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}