using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomOutZone : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float originalZoom;
    [SerializeField] float zoomOut = 60;

    [SerializeField] float zoomSpeed = 1;

    bool canRemoveZoom = false;
    void Start()
    {
        originalZoom = camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRemoveZoom)
        {
            if (camera.orthographicSize > 6)
            {
                print("is bigger");
                camera.orthographicSize -= zoomSpeed * Time.deltaTime;
                // originalZoom -= 0.5f;
            }
        }
        print("canremovezoom " + canRemoveZoom);

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
        canRemoveZoom = false;
        if (collision.CompareTag("Player"))
        {
            if (camera.orthographicSize < zoomOut)
            {
                camera.orthographicSize += zoomSpeed * Time.deltaTime;
               
            }
        }

    }
}
