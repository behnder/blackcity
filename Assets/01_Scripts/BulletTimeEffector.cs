using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletTimeEffector : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) // Trigger bullet time with the 'B' key (you can change this trigger)
        {
            StartCoroutine(EnterBulletTime());
        }
    }

    private IEnumerator EnterBulletTime()
    {
        // Slow down time over 0.5 seconds
        float duration = 0.5f;
        float targetTimeScale = 0.5f;

        while (Time.timeScale > targetTimeScale)
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, targetTimeScale, Time.deltaTime / duration);

            // If you want to maintain regular player speed, set their time scale to 1.0 here

            yield return null;
        }

        // Ensure that time scale is exactly the target value
        Time.timeScale = targetTimeScale;

        // Perform actions during bullet time

        // Exit bullet time
        StartCoroutine(ExitBulletTime());
    }

    private IEnumerator ExitBulletTime()
    {
        // Return to normal time over 0.5 seconds
        float duration = 0.5f;
        float targetTimeScale = 1.0f;

        while (Time.timeScale < targetTimeScale)
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, targetTimeScale, Time.deltaTime / duration);

            // If you want to maintain regular player speed, set their time scale to 1.0 here

            yield return null;
        }

        // Ensure that time scale is exactly the target value
        Time.timeScale = targetTimeScale;

        // Perform actions after exiting bullet time
    }
}
