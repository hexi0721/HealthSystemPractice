using UnityEngine;
using System;

public class FlyingBodyCamera : MonoBehaviour
{


    Func<Vector3> GetMovePostionFunc;
    public void GetMovePostion(Vector3 targetPos)
    {
        SetGetMovePostionFunc(() => targetPos);
    }

    public void SetGetMovePostionFunc(Func<Vector3> GetMovePostionFunc)
    {
        this.GetMovePostionFunc = GetMovePostionFunc;
    }


    public void SetUp(Func<Vector3> GetMovePostionFunc)
    {
        this.GetMovePostionFunc = GetMovePostionFunc;
    }


    private void Update()
    {
        CameraMoveAction();

    }

    private void CameraMoveAction()
    {
        Vector3 movePosition = GetMovePostionFunc();
        movePosition.z = transform.position.z;

        float distance = Vector3.Distance(movePosition, transform.position);
        Vector3 direction = (movePosition - transform.position).normalized;
        float moveSpeed = 1f;

        if (distance > 0f)
        {

            Vector3 nextFrameMovePositon = transform.position + distance * direction * moveSpeed * Time.deltaTime;

            float diffDistance = Vector3.Distance(nextFrameMovePositon, movePosition);
            if (diffDistance > distance)
            {
                transform.position = movePosition;
            }

            transform.position = nextFrameMovePositon;
        }
    }



}
