using System;
using UnityEngine;

public class BouncyGrenade : MonoBehaviour
{

    Action<Vector3> OnExplodeAction;

    public static void Create(GameObject go , Vector3 spawnPos , Vector3 targetPos , Action<Vector3> OnExplodeAction)
    {
        BouncyGrenade bouncyGrenade = Instantiate(go, spawnPos, Quaternion.identity).GetComponent<BouncyGrenade>();

        bouncyGrenade.SetUp(targetPos , OnExplodeAction);
    }

    float timer = 2f;
    int bouncyState;

    private void SetUp(Vector3 targetPos , Action<Vector3> OnExplodeAction)
    {
        this.OnExplodeAction = OnExplodeAction;
        
        Vector3 dir = (targetPos - transform.position).normalized;
        
        float moveSpeed = 20f;
        GetComponent<Rigidbody2D>().linearVelocity = dir * moveSpeed;
        
        transform.localEulerAngles = new Vector3(0, 0 , Utils.GetAngleFromVector(dir) - 90);

    }


    private void Update()
    {
        

        switch (bouncyState)
        {
            case 0:

                transform.localScale += 2f * Vector3.one * Time.deltaTime;
                if(transform.localScale.x >= 1f)
                {
                    bouncyState = 1;
                }

                break;

            case 1:

                transform.localScale -= 3f * Vector3.one * Time.deltaTime;
                if (transform.localScale.x <= 0.5f)
                {
                    bouncyState = 2;
                }

                break;

            case 2:

                break;
        }


        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            ExplodeGrenade();
        }

    }

    private void ExplodeGrenade()
    {
        OnExplodeAction(transform.position);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ExplodeContact"))
        {
            ExplodeGrenade();
        }
    }

}
