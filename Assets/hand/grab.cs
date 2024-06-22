using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    public float grabDistance = 2.0f; // Maximum distance to grab objects
    public float grabSmoothness = 10.0f; // Smoothness of the grab movement
    public KeyCode grabKey = KeyCode.Mouse0; // Key to grab objects

    private GameObject grabbedObject = null;
    private Transform grabbedObjectParent = null;
    private Vector3 originalObjectPosition;
    private bool isGrabbing = false;

    void Update()
    {
        if (Input.GetKeyDown(grabKey))
        {
            if (isGrabbing)
            {
                ReleaseObject();
            }
            else
            {
                TryGrabObject();
            }
        }

        if (isGrabbing)
        {
            MoveObject();
        }
    }

    void TryGrabObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, grabDistance))
        {
            if (hit.collider.gameObject.CompareTag("Grabbable"))
            {
                grabbedObject = hit.collider.gameObject;
                grabbedObjectParent = grabbedObject.transform.parent;
                originalObjectPosition = grabbedObject.transform.position;
                grabbedObject.transform.SetParent(transform);
                grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                isGrabbing = true;
            }
        }
    }

    void MoveObject()
    {
        if (grabbedObject != null)
        {
            Vector3 desiredPosition = transform.position + transform.forward * grabDistance;
            grabbedObject.transform.position = Vector3.Lerp(grabbedObject.transform.position, desiredPosition, Time.deltaTime * grabSmoothness);
        }
    }

    void ReleaseObject()
    {
        if (grabbedObject != null)
        {
            grabbedObject.transform.SetParent(grabbedObjectParent);
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject = null;
            isGrabbing = false;
        }
    }
}