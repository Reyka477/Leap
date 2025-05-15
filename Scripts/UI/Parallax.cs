using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform cameraTransform;      
    public float parallaxMultiplier = 0.5f; // 0.0–1.0 — чем меньше, тем "дальше" фон

    private Vector3 previousCameraPosition;

    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

        previousCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - previousCameraPosition;
        
        transform.position += new Vector3(deltaMovement.x * parallaxMultiplier, 0f, 0f);

        previousCameraPosition = cameraTransform.position;
    }
}