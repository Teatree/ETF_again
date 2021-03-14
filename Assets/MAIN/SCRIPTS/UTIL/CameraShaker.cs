using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public static CameraShaker cameraShaker;
    // Transform of the GameObject you want to shake
    private Transform transform;

    // A measure of magnitude for the shake. Tweak based on your preference
    private float shakeMagnitude = 0.7f;

    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 1.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;

    public void TriggerShake()
    {
        StartCoroutine(Shake(1.0f));
    }

    void Awake()
    {
        cameraShaker = this;
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    public IEnumerator Shake(float duration)
    {
        float elapsedTime = 0;

        initialPosition = transform.localPosition;

        while (elapsedTime < duration)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        transform.localPosition = initialPosition;
    }
}
