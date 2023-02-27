using UnityEngine;

public class ShadowCastingSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Transform shadowObject;
    public Light lightSource;

    void Update()
    {
        // Calculate the position of the shadow based on the light source and the position of the object casting the shadow
        Vector3 shadowPosition = new Vector3(shadowObject.position.x, 0.1f, shadowObject.position.z);
        float shadowSize = spriteRenderer.bounds.size.x / 2f;

        // Set the properties of the light that will cast the shadow
        lightSource.transform.position = shadowPosition + Vector3.up * 2f;
        lightSource.range = shadowSize * 4f;

        // Enable the sprite to cast a shadow
        spriteRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
    }
}
