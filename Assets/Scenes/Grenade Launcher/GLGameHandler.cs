using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GLPlayerHandler;


public class GLGameHandler : MonoBehaviour
{

    [SerializeField] GLPlayerHandler playerHandler;
    IPlayerInterface playerInterface;

    [SerializeField] Transform pfEnemy;
    [SerializeField] GameObject pfBouncyGrenade;
    [SerializeField] GameObject pfStickyGrenade;
    [SerializeField] Transform pfExplosion;

    [SerializeField] Transform followingTarget;
    
    private void Start()
    {
        //playerHandler.OnShoot += playerHandler_OnShoot;
        StartCoroutine(SpawnEnemy());

        playerInterface = playerHandler;
    }


    private void Update()
    {
        GetCameraPos();

        if (Input.GetMouseButtonDown(0))
        {
            if(BouncyGrenade.HasAmmo())
            {
                BouncyGrenade.Create(pfBouncyGrenade, playerInterface.GetGunEndPoinitPosition(), playerInterface.GetShootPostion(), OnGrenadeExplode);
            }
            
        }


    }

    private void GetCameraPos()
    {
        Vector3 mousePos = Utils.GetMouseWorldPos();
        Vector3 playerPos = playerHandler.GetPlayerPos();

        Vector3 dir = (mousePos - playerPos).normalized;

        followingTarget.position = playerPos + dir * 1.5f;

    }
    /*
    private void playerHandler_OnShoot(object sender, GLPlayerHandler.OnShootEventArgs e)
    {

        switch (e.weaponState)
        {
            case 0:
                BouncyGrenade.Create(pfBouncyGrenade, e.gunEndPoinitPosition, e.shootPostion, OnGrenadeExplode);
                break;

            case 1:
                StickyGrenade.Create(pfStickyGrenade, e.gunEndPoinitPosition, e.shootPostion, OnGrenadeExplode);
                break;
        }
        
    }
    */
    private void OnGrenadeExplode(Vector3 position)
    {
        Instantiate(pfExplosion, position, Quaternion.identity);

        float explodeRadius = 5f;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, explodeRadius);

        foreach (var collider in colliders)
        {
            GLSlime glSlime = collider.GetComponent<GLSlime>();
            if (glSlime != null)
            {
                glSlime.Damaged(2);
                CameraShake.Instance.ShakeCamera(1f, .5f);

            }
        }

    }


    private IEnumerator SpawnEnemy()
    {

        while (true)
        {

            GLSlime glSlime =  (Instantiate(pfEnemy, new Vector3(Random.Range(-10, 11), Random.Range(-5, 5)), Quaternion.identity)).GetComponent<GLSlime>();
            glSlime.SetUp(2, () => playerHandler.GetPlayerPos());

            yield return new WaitForSeconds(2);
        }

    }

    public interface IPlayerInterface
    {
        Vector3 GetGunEndPoinitPosition();
        Vector3 GetShootPostion();
        // void PlayReload();


    }

}
