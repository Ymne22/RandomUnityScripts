using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TiltShiftEffect : MonoBehaviour
{
    public float blurArea = 1.0f;
    public float maxBlurSize = 5.0f;
    public float blurStrength = 1.0f;

    private Camera cam;
    private Material blurMaterial;
    private RenderTexture rt;

    private void Start()
    {
        cam = GetComponent<Camera>();

        // Load the blur material
        blurMaterial = new Material(Shader.Find("Hidden/PostProcess/TiltShift"));

        // Create a render texture for the blur effect
        rt = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.DefaultHDR);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // Set the shader parameters
        blurMaterial.SetFloat("_BlurArea", blurArea);
        blurMaterial.SetFloat("_MaxBlurSize", maxBlurSize);
        blurMaterial.SetFloat("_BlurStrength", blurStrength);

        // Render the scene into the render texture
        Graphics.Blit(source, rt);

        // Set the render texture as the source for the blur effect
        blurMaterial.SetTexture("_MainTex", rt);

        // Apply the blur effect to the scene and output to the destination
        Graphics.Blit(source, destination, blurMaterial);
    }
}