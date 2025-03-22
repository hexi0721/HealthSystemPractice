using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;



public class GameHandler : MonoBehaviour
{
    �ͩR�t�� �ͩR�t��;
    [SerializeField] Button damageButton;
    [SerializeField] Button healButton;

    [SerializeField] Transform pf_�������;

    // ���Y �洫����
    [SerializeField] PlayerCamera playerCamera;
    [SerializeField] Transform player1;
    [SerializeField] Transform player2;
    [SerializeField] Transform player3;
    [SerializeField] Button �������a1;
    [SerializeField] Button �������a2;
    [SerializeField] Button �������a3;
    // Zoom In  &&  Zoom Out
    [SerializeField] Button �Ԫ�;
    [SerializeField] Button �Ի�;
    float zoom = 10f;

    public event EventHandler OnCameraRandomPositionAndZoom;

    void Start()
    {
        �ͩR�t�� = new �ͩR�t��(100);

        Transform tr_������� = Instantiate(pf_�������, new Vector3(0, 1), Quaternion.identity);
        HealthBar ������� = tr_�������.GetComponent<HealthBar>();

        �������.SetUp(�ͩR�t��);


        playerCamera.SetUp(() => player1.position, () => zoom); // playerCamera.SetUp(() => {return player.position;});
        �������a1.onClick.AddListener(() => { playerCamera.SetGetNewCameraFollowFunc(() => player1.position); playerCamera.GetCameraZoom(5f); });
        �������a2.onClick.AddListener(() => { playerCamera.GetNewCameraFollow(player2.position); playerCamera.GetCameraZoom(7f);    });
        �������a3.onClick.AddListener(() => { playerCamera.SetGetNewCameraFollowFunc(() => player3.position); playerCamera.GetCameraZoom(10f); });
        OnCameraRandomPositionAndZoom += OnCameraRandomPositionAndZoomChanged;
        float timer = 5f;
        StartCoroutine(TriggerCameraRandomPositionAndZoom(timer));

        �Ԫ�.onClick.AddListener(() =>
        {
            zoom -= 1;
            if (zoom < 3)
                zoom = 3;

            playerCamera.GetCameraZoom(zoom);


        });

        �Ի�.onClick.AddListener(() =>
        {
            zoom += 1;
            if (zoom > 10)
                zoom = 10;

            playerCamera.GetCameraZoom(zoom);


        });

        
        damageButton.onClick.AddListener(() =>
        {
            �ͩR�t��.����ˮ`(10);
            Debug.Log(�ͩR�t��.��q);
        });

        healButton.onClick.AddListener(() =>
        {
            �ͩR�t��.�v¡(5);
            Debug.Log(�ͩR�t��.��q);
        });

    }

    private void OnCameraRandomPositionAndZoomChanged(object sender, EventArgs e)
    {

        Vector3 randCameraPos = new Vector3(UnityEngine.Random.Range(-15 , 10) , UnityEngine.Random.Range(-10, 10));
        float randCameraZoon = UnityEngine.Random.Range(5f , 10f);

        playerCamera.GetNewCameraFollow(randCameraPos); 
        playerCamera.GetCameraZoom(randCameraZoon);

    }

    private IEnumerator TriggerCameraRandomPositionAndZoom(float timer)
    {
        while (true)
        {
            OnCameraRandomPositionAndZoom?.Invoke(this, EventArgs.Empty);
            yield return new WaitForSeconds(timer); // �C�j5��Ĳ�o�@��
        }
    }

}
