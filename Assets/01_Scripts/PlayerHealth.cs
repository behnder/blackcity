using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] TextMeshProUGUI text; 

    [SerializeField] GameObject healthBar;
    [SerializeField] public int lives;
    private bool isRespawning = false;


    private Transform cameraTransform;
    private Vector3 originalPosition;
    private GameObject checkpoint;


    public float Health { get => health; set => health = value; }

    void Start()
    {
        //Assign lives and health to the GUI
        text.text = lives.ToString();
        healthBar.GetComponent<Slider>().maxValue = Health;

        //Get the transform of the camera to make the shake effect
        cameraTransform = transform;
        originalPosition = cameraTransform.localPosition;
    

    }

 

    private void Update()
    {
        
        healthBar.GetComponent<Slider>().value = health;
        //text.text = Health.ToString();// just for debug purpouses
        if (Health <= 0 && lives <= 0)
        {
            if (!isRespawning)
            {
            Shake(0.2f, 0.1f);
            Invoke("ReloadGame", 1.7f);

            }
        }
        else if (lives > 0 && Health <= 0 && !isRespawning)
        {
            isRespawning = true;
            StartCoroutine("GoToTheCheckPoint");
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            
            checkpoint = other.gameObject;
        }
    }

    IEnumerator GoToTheCheckPoint()
    {
        yield return new WaitForSeconds(2);
        Health = 400;
        gameObject.transform.position = checkpoint.gameObject.transform.position;
        lives--;
        text.text = lives.ToString();
        isRespawning = false; // this prevent to count down the lives infinitely inside the Update
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
