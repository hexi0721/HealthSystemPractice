using System.Collections;
using UnityEngine;

public class FlyingBodyGH : MonoBehaviour
{

    [SerializeField] FlyingBodyCamera flyingBodyCamera;
    [SerializeField] Transform trackSprite;

    [SerializeField] GameObject blueSlime;

    private void Start()
    {
        flyingBodyCamera.SetUp(() => trackSprite.position);


        // 生成史萊姆 & 持續靠近 trackSprite
        float spawnTime = 4f;
        StartCoroutine(InstantiateBlueSlime(spawnTime));

        
    }

    private void Update()
    {
        MouseLeftButtonDown();
    }


    private void MouseLeftButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pointerPos = flyingBodyCamera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            pointerPos.z = transform.position.z;

            RaycastHit2D hit = Physics2D.Raycast(pointerPos, Vector2.zero, Mathf.Infinity);

            if (hit.collider != null && hit.collider.CompareTag("Slime"))
            {
                // Debug.Log(hit.collider.name);
                hit.collider.GetComponent<Slime>().Damaged(1);

                if(hit.collider.GetComponent<Slime>().GetHp() <= 0)
                {
                    Debug.Log("Shake Camera");
                    StartCoroutine(ShakeCamera(.1f, .05f));
                    
                }
            }
        }
    }

    public IEnumerator InstantiateBlueSlime(float spawnTime)
    {
        while (true)
        {

            GameObject go = Instantiate(blueSlime, new Vector3(Random.Range(-10, 11), Random.Range(-5, 5)), Quaternion.identity) as GameObject;
            go.GetComponent<Slime>().SetUp(() => trackSprite.position);


            yield return new WaitForSeconds(spawnTime);
        }

    }

    public IEnumerator ShakeCamera(float duration , float magnitude)
    {

        float elapsed = 0.0f;
        bool b = true;
        float tmp = 0f;
        while (elapsed < duration)
        {

            if (b)
            {
                tmp += Time.deltaTime;
                if (tmp > magnitude)
                {
                    tmp = magnitude;
                    b = false;
                }
            }
            else
            {
                tmp -= Time.deltaTime;
                if (tmp < -magnitude)
                {
                    tmp = -magnitude;
                    b = true;
                }
            }

            flyingBodyCamera.transform.localPosition += new Vector3(tmp, 0, 0);

            elapsed += Time.deltaTime;

            yield return null;
        }

        flyingBodyCamera.transform.position = new Vector3(trackSprite.position.x , trackSprite.position.y , flyingBodyCamera.transform.position.z) ;
        
    }

}
