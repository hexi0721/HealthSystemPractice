using System;
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

        HandleMeleeInput();
        // HandleGrenadeInput();

    }

    private void HandleMeleeInput()
    {
        if (Input.GetMouseButtonDown(0))
        {

            int enemyKillAmount = DamageEnemyInRange(playerInterface.GetPlayerPos() , 2f);

            if(enemyKillAmount > 0)
            {
                CameraShake.Instance.ShakeCamera(1f, 1f);
                Eyelander.AddBonus();
                playerInterface.SetMoveSpeedBonus(Eyelander.GetBonusSpeed());
            }
            
        }
    }

    private void HandleGrenadeInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (StickyGrenade.HasAmmo())
            {
                StickyGrenade.Create(pfStickyGrenade, playerInterface.GetGunEndPoinitPosition(), playerInterface.GetShootPostion(), OnGrenadeExplode);
            }

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (StickyGrenade.CanReloadAmmo())
            {
                playerInterface.PlayReload(() => StickyGrenade.ReloadAmmo());
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            StickyGrenade.ExplodeAllStickyGrenade();
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
        DamageEnemyInRange(position , explodeRadius);

        CameraShake.Instance.ShakeCamera(1f, .5f);
    }

    private int DamageEnemyInRange(Vector3 position , float explodeRadius)
    {
        int killAmount = 0;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, explodeRadius);

        foreach (var collider in colliders)
        {
            GLSlime glSlime = collider.GetComponent<GLSlime>();
            if (glSlime != null)
            {
                glSlime.Damaged(2);
                killAmount++;

            }
        }
        return killAmount;
    }

    private IEnumerator SpawnEnemy()
    {

        while (true)
        {

            GLSlime glSlime =  (Instantiate(pfEnemy, new Vector3(UnityEngine.Random.Range(-10, 11), UnityEngine.Random.Range(-5, 5)), Quaternion.identity)).GetComponent<GLSlime>();
            glSlime.SetUp(2, () => playerHandler.GetPlayerPos());

            yield return new WaitForSeconds(2);
        }

    }

    public interface IPlayerInterface
    {
        Vector3 GetPlayerPos();
        Vector3 GetGunEndPoinitPosition();
        Vector3 GetShootPostion();
        void PlayReload(Action action);

        void SetMoveSpeedBonus(float bonusSpeed);
    }

}
