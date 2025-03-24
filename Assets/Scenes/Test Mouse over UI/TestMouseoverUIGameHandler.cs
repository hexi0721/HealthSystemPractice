using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestMouseoverUIGameHandler : MonoBehaviour
{

    [SerializeField] Transform ª±®a1;
    Vector3 destinaiton;

    private void Start()
    {
        
    }

    private void Update()
    {
        
        if(Input.GetMouseButton(0) && !IsMouseOverUIGetThrough())
        {
            destinaiton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destinaiton.z = 0;
        }

        float speed = 1f;
        ª±®a1.position = Vector3.Lerp(ª±®a1.position, destinaiton, speed * Time.deltaTime);


    }

    private bool IsMouseOverUI()
    {
        
        return EventSystem.current.IsPointerOverGameObject();
    }

    private bool IsMouseOverUIGetThrough()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);

        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResult = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResult);
        
        for (int i = 0;i < raycastResult.Count;i++)
        {
            if (raycastResult[i].gameObject.GetComponent<MouserUIGetThrough>() != null)
            {
                raycastResult.RemoveAt(i);
                i--;
            }
        }


        return raycastResult.Count > 0 ;

    }


}
