using System;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    生命系統 healthSystem;

    public void SetUp(生命系統 hs)
    {
        hs.OnHealthChanged += HealthSystem_OnHealthChanged;
        this.healthSystem = hs;

    }

    private void HealthSystem_OnHealthChanged(object sender, EventArgs e)
    {
        transform.Find("血條").localScale = new Vector3(healthSystem.血量百分比(), transform.localScale.y);
    }


}
