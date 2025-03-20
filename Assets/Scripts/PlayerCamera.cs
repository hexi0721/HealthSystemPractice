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

        Application.targetFrameRate = fps; // 當fps越小   Time.deltaTime 越大

        Vector3 cameraFollowPosition = GetFollowPositionFunc();
        cameraFollowPosition.z = transform.position.z;
        
        Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
        float distance = Vector3.Distance(cameraFollowPosition , transform.position);
        float cameraMoveSpeed = 10f;


        if(distance > 0)
        {
            Vector3 newCameraPostion = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;
            float newDistance = Vector3.Distance(newCameraPostion , cameraFollowPosition);

            if(newDistance > distance) // 如果下一幀移動到的鏡頭位置離目標位置  遠於  先前當前幀的鏡頭位置到目標位置 就不必使用下一幀的鏡頭位置 直接使用目標位置
            {
                newCameraPostion = cameraFollowPosition;
            }
                

            transform.position = newCameraPostion;
        }


    }

}
