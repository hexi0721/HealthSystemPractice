using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    ネ㏑╰参 ネ㏑╰参;
    [SerializeField] Button damageButton;
    [SerializeField] Button healButton;

    [SerializeField] Transform pf_﹀兵ン;

    void Start()
    {
        ネ㏑╰参 = new ネ㏑╰参(100);

        Transform tr_﹀兵ン =  Instantiate(pf_﹀兵ン , new Vector3(0 , 1) , Quaternion.identity);
        HealthBar ﹀兵ン = tr_﹀兵ン.GetComponent<HealthBar>();

        ﹀兵ン.SetUp(ネ㏑╰参);

        /*
        ネ㏑╰参.端甡(10);
        Debug.Log(ネ㏑╰参.﹀秖);

        ネ㏑╰参.獀隆(5);
        Debug.Log(ネ㏑╰参.﹀秖);
        */

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
