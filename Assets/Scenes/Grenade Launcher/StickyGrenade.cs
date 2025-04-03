using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StickyGrenade : MonoBehaviour
{

    private static int ammoMax = 8;
    private static int ammo = ammoMax;


    Action<Vector3> OnExplodeAction;

    private static List<StickyGrenade> stickyGrenadeList;


    public static void ExplodeAllStickyGrenade()
    {
        foreach (var stickyGrenade in stickyGrenadeList)
        {
            stickyGrenade.ExplodeGrenade();
        }
        stickyGrenadeList.Clear();
    }

    public static bool HasAmmo()
    {
        return ammo > 0;
    }

    public static bool CanReloadAmmo()
    {
        return ammo < ammoMax;
    }

    public static void ReloadAmmo()
    {
        ammo = ammoMax;
    }


    public static void Create(GameObject go, Vector3 spawnPos, Vector3 targetPos, Action<Vector3> OnExplodeAction)
    {
        StickyGrenade StickyGrenade = Instantiate(go, spawnPos, Quaternion.identity).GetComponent<StickyGrenade>();



        if (stickyGrenadeList == null)
        {
            stickyGrenadeList = new List<StickyGrenade>();

        }

        StickyGrenade.SetUp(targetPos, OnExplodeAction);
        stickyGrenadeList.Add(StickyGrenade);

        if (stickyGrenadeList.Count > 8)
        {
            stickyGrenadeList[0].ExplodeGrenade();
            stickyGrenadeList.RemoveAt(0);
        }

        ammo--;

    }

    private void SetUp(Vector3 targetPos, Action<Vector3> OnExplodeAction)
    {
        this.OnExplodeAction = OnExplodeAction;

        Vector3 dir = (targetPos - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, targetPos);

        float moveSpeed = Mathf.Clamp(20f * distance, 10f, 20f);
        GetComponent<Rigidbody2D>().linearVelocity = dir * moveSpeed;
        GetComponent<Rigidbody2D>().angularVelocity = -1000f;
        transform.localEulerAngles = new Vector3(0, 0, Utils.GetAngleFromVector(dir) - 90);


    }

    int StickyState = 0;
    private void Update()
    {


        switch (StickyState)
        {
            case 0:

                transform.localScale += 2f * Vector3.one * Time.deltaTime;
                if (transform.localScale.x >= 1f)
                {
                    StickyState = 1;
                }

                break;

            case 1:

                transform.localScale -= 3f * Vector3.one * Time.deltaTime;
                if (transform.localScale.x <= 0.5f)
                {
                    StickyState = 2;
                }

                break;

            case 2:

                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StopMoving();
    }

    private void StopMoving()
    {
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<Collider2D>());
    }


    private void ExplodeGrenade()
    {
        OnExplodeAction(transform.position);
        Destroy(gameObject);
    }

}
