using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    �ͩR�t�� �ͩR�t��;
    [SerializeField] Button damageButton;
    [SerializeField] Button healButton;

    [SerializeField] Transform pf_�������;

    void Start()
    {
        �ͩR�t�� = new �ͩR�t��(100);

        Transform tr_������� =  Instantiate(pf_������� , new Vector3(0 , 1) , Quaternion.identity);
        HealthBar ������� = tr_�������.GetComponent<HealthBar>();

        �������.SetUp(�ͩR�t��);

        /*
        �ͩR�t��.����ˮ`(10);
        Debug.Log(�ͩR�t��.��q);

        �ͩR�t��.�v¡(5);
        Debug.Log(�ͩR�t��.��q);
        */

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
