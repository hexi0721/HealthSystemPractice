using UnityEngine;
using UnityEngine.UI;


public class 產 : MonoBehaviour
{
    ネ㏑╰参 ネ㏑╰参;
    [SerializeField] Button damageButton;
    [SerializeField] Button healButton;

    void Start()
    {
        ネ㏑╰参 = new ネ㏑╰参(100);

        ネ㏑╰参.端甡(10);
        Debug.Log(ネ㏑╰参.﹀秖);

        ネ㏑╰参.獀隆(5);
        Debug.Log(ネ㏑╰参.﹀秖);


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
