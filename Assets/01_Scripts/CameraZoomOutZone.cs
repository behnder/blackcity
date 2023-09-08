using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomOutZone : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float originalZoom;
    [SerializeField] float zoomOut = 60;
    [SerializeField] float ortographicSize;

    [SerializeField] float zoomSpeed = 1;

    public bool canRemoveZoom = false;

    void Start()
    {
        originalZoom = camera.orthographicSize; 
    }


    void Update()
    {

        if (canRemoveZoom && camera.orthographicSize > 6)
        {
            float newOrthoSize = Mathf.Lerp(camera.orthographicSize, 6f, zoomSpeed * Time.deltaTime);
            camera.orthographicSize = newOrthoSize;
        }
        else if (!canRemoveZoom && camera.orthographicSize < originalZoom)
        {
            float newOrthoSize = Mathf.Lerp(camera.orthographicSize, originalZoom, zoomSpeed * Time.deltaTime);
            camera.orthographicSize = newOrthoSize;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
     
        if (collision.CompareTag("Player"))
        {
            canRemoveZoom = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canRemoveZoom = false;

            if (camera.orthographicSize < zoomOut)
            {
                float newOrthoSize = Mathf.Lerp(camera.orthographicSize, zoomOut, zoomSpeed * Time.deltaTime);
                camera.orthographicSize = newOrthoSize;
            }
        }

    }


}
