using UnityEngine;

public class Torch : MonoBehaviour
{
    public float duration = 30.0f;
    public float maxDuration = 60.0f;
    public float refillAmount = 10.0f;
    public float refillRatio = 0.5f;

    private Light torchLight;
    private float currentDuration;

    void Start()
    {
        torchLight = GetComponent<Light>();
        currentDuration = duration;
    }

    void Update()
    {
        currentDuration -= Time.deltaTime;

        torchLight.intensity = currentDuration / duration;

        if (currentDuration <= 0.0f)
        {
            torchLight.enabled = false;
            enabled = false;
        }
    }

    public void Refill()
    {
        float refillDuration = Mathf.Min(maxDuration - currentDuration, refillAmount);
        currentDuration += refillDuration * refillRatio;
    }
}
