using System;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    �ͩR�t�� healthSystem;

    public void SetUp(�ͩR�t�� hs)
    {
        hs.OnHealthChanged += HealthSystem_OnHealthChanged;
        this.healthSystem = hs;

    }

    private void HealthSystem_OnHealthChanged(object sender, EventArgs e)
    {
        transform.Find("���").localScale = new Vector3(healthSystem.��q�ʤ���(), transform.localScale.y);
    }


}
