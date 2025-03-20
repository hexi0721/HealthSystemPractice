using UnityEngine;
using UnityEngine.UI;

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
    

    void Start()
    {
        �ͩR�t�� = new �ͩR�t��(100);

        Transform tr_������� =  Instantiate(pf_������� , new Vector3(0 , 1) , Quaternion.identity);
        HealthBar ������� = tr_�������.GetComponent<HealthBar>();

        �������.SetUp(�ͩR�t��);

        playerCamera.SetUp(() => player1.position); // playerCamera.SetUp(() => {return player.position;});
        �������a1.onClick.AddListener(() => { playerCamera.SetNewCameraFollow(() => player1.position); });
        �������a2.onClick.AddListener(() => { playerCamera.SetNewCameraFollow(() => player2.position); });
        �������a3.onClick.AddListener(() => { playerCamera.SetNewCameraFollow(() => player3.position); });


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


}
