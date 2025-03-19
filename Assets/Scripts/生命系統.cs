using UnityEngine;
using System;

public class ネ㏑╰参
{

    int 程﹀秖;
    public int ﹀秖 { get; private set; }

    public event EventHandler OnHealthChanged;

    public ネ㏑╰参(int 程﹀秖)
    {
        this.程﹀秖 = 程﹀秖;
        ﹀秖 = 程﹀秖;
    }

    public float ﹀秖κだゑ()
    {
        return (float)﹀秖 / 程﹀秖;
    }

    public void 端甡(int damageAmount)
    {
        ﹀秖 -= damageAmount;
        if (﹀秖 < 0)
        {
            ﹀秖 = 0;
        }
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

    public void 獀隆(int healAmount)
    {
        ﹀秖 += healAmount;
        if (﹀秖 > 程﹀秖)
        {
            ﹀秖 = 程﹀秖;
        }
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

}
