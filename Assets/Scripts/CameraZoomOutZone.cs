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

    bool canRemoveZoom = false;

    void Start()
    {
        originalZoom = camera.orthographicSize;
       
    }


    void Update()
    {
        ortographicSize = camera.orthographicSize;
        //if (canRemoveZoom)
        //{
        //    if (camera.orthographicSize > 6)
        //    {
        //        camera.orthographicSize -= zoomSpeed * Time.deltaTime;
        //    }
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            while (camera.orthographicSize > originalZoom)
            {
                camera.orthographicSize -= 0.1f * Time.deltaTime;
                
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (camera.orthographicSize < zoomOut)
            {
                camera.orthographicSize += zoomSpeed * Time.deltaTime;
            }
        }

    }

    IEnumerator RestoreZoom()
    {
        camera.orthographicSize -= 0.1f * Time.deltaTime;
        yield return new WaitForSeconds(0.5f);

    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    canRemoveZoom = false;

    //}

}
