using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartUIDragger : MonoBehaviour
{
    [SerializeField] protected GameObject dragObject;

    protected Sprite dragImage = null;

    public void DisplayPartDrag(IPart currentPart)
    {
        //We need an image attached to parts in order to get the correct image here.
        //dragObject. = (Part)currentPart.partImage;
        dragObject.SetActive(true);
    }

    public void EndPartDrag()
    {
        //dragImage = null;
        dragObject.SetActive(false);
    }

    protected void Start()
    {
        dragImage = dragObject.GetComponent<Image>().sprite;
    }

    protected void Update()
    {
        if (dragObject.activeSelf)
            FollowMouse();
    }

    protected void FollowMouse()
    {
        dragObject.transform.position = Input.mousePosition;
    }
}
