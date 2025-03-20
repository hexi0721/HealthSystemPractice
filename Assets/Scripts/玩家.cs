using UnityEngine;
using UnityEngine.UI;


public class 玩家 : MonoBehaviour
{

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 取得水平和垂直軸的數值
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 使用這些數值來控制角色的移動或其他行為
        Vector3 movement = new Vector3(horizontal, vertical);
        transform.Translate(movement * Time.deltaTime);

        // 可以將這些數值傳遞給動畫控制器
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }
}
