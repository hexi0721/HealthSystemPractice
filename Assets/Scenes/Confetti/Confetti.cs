using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Confetti : MonoBehaviour
{

    [SerializeField] Color[] colorArray;
    [SerializeField] Transform pfBlueSlime;

    List<BlueSlime> blueSlimeList;

    float timer;
    float timerMax = 0.5f;

    private void Awake()
    {
        blueSlimeList = new List<BlueSlime>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer += timerMax;

            int spawnAmount = Random.Range(1 , 4);
            for (int i = 0;i < spawnAmount;i++)
            {
                Spwan();
            }
            
        }

        foreach(var blueSlime in new List<BlueSlime>(blueSlimeList))
        {
            if(blueSlime.Update())
            {
                blueSlimeList.Remove(blueSlime);
            }
            
        }

    }

    private void Spwan()
    {
        float width = GetComponent<RectTransform>().rect.width;
        float height = GetComponent<RectTransform>().rect.height;

        Vector3 anchorPosiion = new Vector3(Random.Range(-width / 2 , width / 2) , height / 2);

        int colorIndex = Random.Range(0 , colorArray.Length);

        blueSlimeList.Add(new BlueSlime(pfBlueSlime, transform, anchorPosiion , colorArray[colorIndex] , -height / 2));
    }


    private class BlueSlime
    {
        Transform transform;
        Vector3 anchorPosition;
        RectTransform rectTransform;

        Vector3 moveAmount;
        Vector3 euler;
        float eulerZSpeed;

        float bound;

        public BlueSlime(Transform pf , Transform container , Vector3 anchorPosition , Color color , float bound)
        {
            this.anchorPosition = anchorPosition;
            transform = Instantiate(pf , container);
            rectTransform = transform.GetComponent<RectTransform>();

            // rectTransform.anchoredPosition = anchorPosition;

            moveAmount = new Vector3(0, Random.Range(-50f, -100f));

            rectTransform.sizeDelta *= Random.Range(0.5f, 1.2f);

            euler = new Vector3(0, 0, Random.Range(0, 360f));
            eulerZSpeed = Random.Range(100f, 200f);
            eulerZSpeed *= Random.Range(0, 2) == 0 ? 1f : -1f;

            transform.GetComponent<Image>().color = color;

            this.bound = bound;
        }

        public bool Update()
        {
            
            anchorPosition += moveAmount * Time.deltaTime;
            rectTransform.anchoredPosition = anchorPosition;

            euler.z += eulerZSpeed * Time.deltaTime;
            rectTransform.eulerAngles = euler;

            if(rectTransform.anchoredPosition.y < bound)
            {
                Destroy(transform.gameObject);
                return true;
            }

            return false;

        }

    }





}
