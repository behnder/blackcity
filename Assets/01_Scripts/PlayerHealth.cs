using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health;
    //[SerializeField] Text text; // just for debug purpouses
 
    [SerializeField] GameObject healthBar;


    private Transform cameraTransform;
    private Vector3 originalPosition;
   

    public float Health { get => health; set => health = value; }

    void Start()
    {
        healthBar.GetComponent<Slider>().maxValue = Health;
   

        cameraTransform = transform;
        originalPosition = cameraTransform.localPosition;
    }

    private void Update()
    {
        healthBar.GetComponent<Slider>().value = health;
        //text.text = Health.ToString();// just for debug purpouses
        if (Health <= 0)
        {
            Shake(0.3f, 0.2f);
            Invoke("ReloadGame", 1.7f);
        }
    }

   void ReloadGame()
    {
        SceneManager.LoadScene("MainMenu");
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
            originalPosition = cameraTransform.localPosition;
            cameraTransform.localPosition = originalPosition + new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        cameraTransform.localPosition = originalPosition;
    }
}
