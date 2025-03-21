using System;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    Func<Vector3> GetFollowPositionFunc;
    Func<float> GetCameraZoomFunc;

    [SerializeField] int fps;
    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    public void SetUp(Func<Vector3> GetFollowPositionFunc , Func<float> GetCameraZoom)
    {
        this.GetFollowPositionFunc = GetFollowPositionFunc;
        this.GetCameraZoomFunc = GetCameraZoom;
    }

    public void GetCameraZoom(float zoom)
    {
        SetGetCameraZoomFunc(() => zoom);
    }

    public void SetGetCameraZoomFunc(Func<float> GetCameraZoomFunc)
    {
        this.GetCameraZoomFunc = GetCameraZoomFunc;
    }

    public void GetNewCameraFollow(Vector3 position)
    {
        SetGetNewCameraFollowFunc(() => position);
    }

    public void SetGetNewCameraFollowFunc(Func<Vector3> GetFollowPositionFunc)
    {
        this.GetFollowPositionFunc = GetFollowPositionFunc;
    }

    public void SetCamera(Camera cam)
    {
        this.cam = cam;
    }

    private void Update()
    {
        HandleMoveMent();
        HandleZoom();

        

    }

    private void HandleZoom()
    {
        float cameraZoom = GetCameraZoomFunc();

        float diffCameraZoom = cameraZoom - cam.orthographicSize;
        float camaraZoomSpeed = 1f;

        cam.orthographicSize += diffCameraZoom * camaraZoomSpeed * Time.deltaTime;

        if (diffCameraZoom > 0)
        {
            if(cam.orthographicSize > cameraZoom)
            {
                cam.orthographicSize = cameraZoom;
            }

        }
        else  // �q�����ɡAdiffCameraZoom �|�O�t�ȡA��FPS�L�p�Acam.orthographicSize += diffCameraZoom * camaraZoomSpeed * Time.deltaTime �����Acam.orthographicSize �̲׷|�p��cameraZoom = 5�A�ҥH��cameraZoom �� cam.orthographicSize;
        {
            if (cam.orthographicSize < cameraZoom)
            {
                cam.orthographicSize = cameraZoom;
            }
            
        }
    }

    private void HandleMoveMent()
    {
        Application.targetFrameRate = fps; // ��fps�V�p   Time.deltaTime �V�j

        Vector3 cameraFollowPosition = GetFollowPositionFunc();
        cameraFollowPosition.z = transform.position.z;

        Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
        float distance = Vector3.Distance(cameraFollowPosition, transform.position);
        float cameraMoveSpeed = 1f;


        if (distance > 0)
        {
            Vector3 newCameraPostion = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;
            float newDistance = Vector3.Distance(newCameraPostion, cameraFollowPosition);

            if (newDistance > distance) // �p�G�U�@�V���ʨ쪺���Y��m���ؼЦ�m  ����  ���e��e�V�����Y��m��ؼЦ�m �N�����ϥΤU�@�V�����Y��m �����ϥΥؼЦ�m
            {
                newCameraPostion = cameraFollowPosition;
            }


            transform.position = newCameraPostion;
        }
    }


}
