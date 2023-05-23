using UnityEngine;

public class DragObject : MonoBehaviour
{
    private bool isDragging;
    private bool isOverDropZone;
    private Vector3 startPosition;
    private Transform startParent;

    public GameObject dropZone; // set the drop zone in the inspector

    private void Start()
    {
        startPosition = transform.position;
        startParent = transform.parent;
    }

    private void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            if (isOverDropZone)
            {
                transform.SetParent(dropZone.transform);
                transform.position = dropZone.transform.position;
                isOverDropZone = false;
                enabled = false; // disable the script to prevent further dragging
            }
            else
            {
                transform.position = startPosition;
            }

            isDragging = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == dropZone)
        {
            isOverDropZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == dropZone)
        {
            isOverDropZone = false;
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 44));
        }
    }
}
