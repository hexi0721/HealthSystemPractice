using UnityEngine;
using UnityEngine.UI;


public class ���a : MonoBehaviour
{

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // ���o�����M�����b���ƭ�
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // �ϥγo�ǼƭȨӱ���⪺���ʩΨ�L�欰
        Vector3 movement = new Vector3(horizontal, vertical);
        transform.Translate(movement * Time.deltaTime);

        // �i�H�N�o�Ǽƭȶǻ����ʵe���
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }
}
