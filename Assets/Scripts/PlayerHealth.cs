using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] Text text;
  
    private Transform cameraTransform;
    private Vector3 originalPosition;
   

    public float Health { get => health; set => health = value; }

    // Start is called before the first frame update
    void Start()
    {
        Health = 300;
       
        cameraTransform = transform;
        originalPosition = cameraTransform.localPosition;
    }

    private void Update()
    {
        text.text = Health.ToString();

        if(Health <= 0)
        {
            Shake(0.5f, 1);
        }
    }

   
    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            cameraTransform.localPosition = originalPosition + new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;

            yield return null;
        }

        cameraTransform.localPosition = originalPosition;
    }
}
