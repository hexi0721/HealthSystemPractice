using UnityEngine;
using System;

public class �ͩR�t��
{

    int �̤j��q;
    public int ��q { get; private set; }

    public event EventHandler OnHealthChanged;

    public �ͩR�t��(int �̤j��q)
    {
        this.�̤j��q = �̤j��q;
        ��q = �̤j��q;
    }

    public float ��q�ʤ���()
    {
        return (float)��q / �̤j��q;
    }

    public void ����ˮ`(int damageAmount)
    {
        ��q -= damageAmount;
        if (��q < 0)
        {
            ��q = 0;
        }
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

    public void �v¡(int healAmount)
    {
        ��q += healAmount;
        if (��q > �̤j��q)
        {
            ��q = �̤j��q;
        }
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

}
