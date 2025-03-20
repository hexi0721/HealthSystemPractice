using System;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    Func<Vector3> GetFollowPositionFunc;

    [SerializeField] int fps;

    public void SetUp(Func<Vector3> GetFollowPositionFunc)
    {
        this.GetFollowPositionFunc = GetFollowPositionFunc;
    }

    public void SetNewCameraFollow(Func<Vector3> GetFollowPositionFunc)
    {
        this.GetFollowPositionFunc = GetFollowPositionFunc;
    }

    private void Update()
    {

        Application.targetFrameRate = fps; // ��fps�V�p   Time.deltaTime �V�j

        Vector3 cameraFollowPosition = GetFollowPositionFunc();
        cameraFollowPosition.z = transform.position.z;
        
        Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
        float distance = Vector3.Distance(cameraFollowPosition , transform.position);
        float cameraMoveSpeed = 10f;


        if(distance > 0)
        {
            Vector3 newCameraPostion = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;
            float newDistance = Vector3.Distance(newCameraPostion , cameraFollowPosition);

            if(newDistance > distance) // �p�G�U�@�V���ʨ쪺���Y��m���ؼЦ�m  ����  ���e��e�V�����Y��m��ؼЦ�m �N�����ϥΤU�@�V�����Y��m �����ϥΥؼЦ�m
            {
                newCameraPostion = cameraFollowPosition;
            }
                

            transform.position = newCameraPostion;
        }


    }

}
