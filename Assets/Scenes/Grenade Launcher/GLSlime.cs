using System;
using UnityEngine;


public class GLSlime : MonoBehaviour
{

    Animator animator;
    [SerializeField] int hp = 2;
    float timer;
    float eulerZ;

    public Func<Vector3> FollowPosition;
    
    public void SetUp(int hp , Func<Vector3> FollowPosition)
    {
        this.hp = hp;
        this.FollowPosition = FollowPosition;
        
    }
    


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        Vector3 movePosition = FollowPosition();
        movePosition.z = transform.position.z;
        if (hp > 0)
        {

            
            Vector3 direction = (movePosition - transform.position).normalized;
            float moveSpeed = 1f;

            transform.position += direction * moveSpeed * Time.deltaTime;



        }
        else if (hp <= 0)
        {
            animator.SetBool("isDead", true);
            GetComponent<Collider2D>().enabled = false;

            Vector3 direction = (transform.position - movePosition).normalized;
            float flySpeed = 10f;

            transform.position += direction * flySpeed * Time.deltaTime;

            float scaleSpeed = 5f;
            transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;

            float eulerSpeed = 360f * 4f;
            eulerZ += eulerSpeed * Time.deltaTime;

            transform.localEulerAngles = new Vector3 (0, 0, eulerZ);

            timer += Time.deltaTime;
            if(timer >= 1f)
            {
                Destroy(gameObject);
            }



        }


    }


    public void Damaged(int damage)
    {
        hp -= damage;
    }

    public int GetHp()
    {
        return hp;
    }
    

}
