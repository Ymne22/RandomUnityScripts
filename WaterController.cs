using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public float scrollSpeed = 0.5f;

    private Material material;

    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        Vector2 offset = new Vector2(Time.time * scrollSpeed, Time.time * scrollSpeed);
        material.SetTextureOffset("_BaseMap", offset);
        material.SetTextureOffset("_BumpMap", offset);
    }
}