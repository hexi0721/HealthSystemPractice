using System;
using System.Collections;
using UnityEngine;
using static GLGameHandler;

public class GLPlayerHandler : MonoBehaviour , IPlayerInterface
{

    [SerializeField] Transform player;
    [SerializeField] Transform gun;
    /*
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPoinitPosition { get; }
        public Vector3 shootPostion { get; }

        public OnShootEventArgs(Vector3 gunEndPoinitPosition, Vector3 shootPostion)
        {
            this.gunEndPoinitPosition = gunEndPoinitPosition;
            this.shootPostion = shootPostion;

        }

    }
    */
    private void Update()
    {
        PlayerMove();
        SetGunPos();

        bonusTImer -= Time.deltaTime;
        if( bonusTImer < 0 )
        {
            Eyelander.ResetBonus();
            SetMoveSpeedBonus(Eyelander.GetBonusSpeed());
        }
    }

    private void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, v, 0) * MoveSpeedBonus;

        player.transform.position += move * 2f * Time.deltaTime;
    }

    private void SetGunPos()
    {
        Vector3 mouserPos = Utils.GetMouseWorldPosZeroZ();
        Vector3 dir = (mouserPos - player.position).normalized;
        float distance = 1f;
        gun.transform.position = player.position + dir * distance;
    }

    public Vector3 GetPlayerPos()
    {
        return player.position;
    }

    public Vector3 GetGunEndPoinitPosition()
    {
        Vector3 mouserPos = Utils.GetMouseWorldPosZeroZ();
        Vector3 dir = (mouserPos - gun.transform.position).normalized;
        float distance = 0.5f;
        return gun.transform.position + dir * distance;
    }

    public Vector3 GetShootPostion()
    {
        Vector3 mouserPos = Utils.GetMouseWorldPosZeroZ();
        
        return mouserPos;
    }

    private float reloadTimer = 1.5f;

    public void PlayReload(Action action)
    {
        StartCoroutine(ReloadingAmmo(action));

    }

    private IEnumerator ReloadingAmmo(Action action)
    {
        yield return new WaitForSeconds(reloadTimer);
        action.Invoke();
    }

    float MoveSpeedBonus = 1;
    float bonusTImer = 0f;
    public void SetMoveSpeedBonus(float MoveSpeedBonus)
    {
        bonusTImer = 2f;
        this.MoveSpeedBonus = MoveSpeedBonus;
    }


}
