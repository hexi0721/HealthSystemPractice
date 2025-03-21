using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    ネ㏑╰参 ネ㏑╰参;
    [SerializeField] Button damageButton;
    [SerializeField] Button healButton;

    [SerializeField] Transform pf_﹀兵ン;

    // 描繷 ユ传代刚
    [SerializeField] PlayerCamera playerCamera;
    [SerializeField] Transform player1;
    [SerializeField] Transform player2;
    [SerializeField] Transform player3;
    [SerializeField] Button ち传產1;
    [SerializeField] Button ち传產2;
    [SerializeField] Button ち传產3;
    // Zoom In  &&  Zoom Out
    [SerializeField] Button ┰;
    [SerializeField] Button ┰环;
    float zoom = 10f;

    void Start()
    {
        ネ㏑╰参 = new ネ㏑╰参(100);

        Transform tr_﹀兵ン = Instantiate(pf_﹀兵ン, new Vector3(0, 1), Quaternion.identity);
        HealthBar ﹀兵ン = tr_﹀兵ン.GetComponent<HealthBar>();

        ﹀兵ン.SetUp(ネ㏑╰参);


        playerCamera.SetUp(() => player1.position, () => zoom); // playerCamera.SetUp(() => {return player.position;});
        ち传產1.onClick.AddListener(() => { playerCamera.SetGetNewCameraFollowFunc(() => player1.position); playerCamera.GetCameraZoom(5f); });
        ち传產2.onClick.AddListener(() => { playerCamera.GetNewCameraFollow(player2.position); playerCamera.GetCameraZoom(7f);    });
        ち传產3.onClick.AddListener(() => { playerCamera.SetGetNewCameraFollowFunc(() => player3.position); playerCamera.GetCameraZoom(10f); });

        ┰.onClick.AddListener(() =>
        {
            zoom -= 1;
            if (zoom < 3)
                zoom = 3;

            playerCamera.GetCameraZoom(zoom);


        });

        ┰环.onClick.AddListener(() =>
        {
            zoom += 1;
            if (zoom > 10)
                zoom = 10;

            playerCamera.GetCameraZoom(zoom);


        });

        
        damageButton.onClick.AddListener(() =>
        {
            ネ㏑╰参.端甡(10);
            Debug.Log(ネ㏑╰参.﹀秖);
        });

        healButton.onClick.AddListener(() =>
        {
            ネ㏑╰参.獀隆(5);
            Debug.Log(ネ㏑╰参.﹀秖);
        });

    }

}
