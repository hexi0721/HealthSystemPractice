using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GLGameHandler : MonoBehaviour
{

    [SerializeField] GLPlayerHandler playerHandler;


    [SerializeField] Transform pfEnemy;
    [SerializeField] GameObject pfBouncyGrenade;
    [SerializeField] Transform pfExplosion;

    [SerializeField] Transform followingTarget;
    
    private void Start()
    {
        playerHandler.OnShoot += playerHandler_OnShoot;
        StartCoroutine(SpawnEnemy());
    }


    private void Update()
    {
        GetCameraPos();
    }

    private void GetCameraPos()
    {
        Vector3 mousePos = Utils.GetMouseWorldPos();
        Vector3 playerPos = playerHandler.GetPlayerPos();

        Vector3 dir = (mousePos - playerPos).normalized;

        followingTarget.position = playerPos + dir * 1.5f;

    }

    private void playerHandler_OnShoot(object sender, GLPlayerHandler.OnShootEventArgs e)
    {
        
        BouncyGrenade.Create(pfBouncyGrenade, e.gunEndPoinitPosition , e.shootPostion , OnGrenadeExplode);
    }

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

}
