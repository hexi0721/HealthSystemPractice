using UnityEngine;

public class ネ㏑╰参
{

    int 程﹀秖;
    public int ﹀秖 { get; private set; }

    public ネ㏑╰参(int 程﹀秖)
    {
        this.程﹀秖 = 程﹀秖;
        ﹀秖 = 程﹀秖;
    }

    public void 端甡(int damageAmount)
    {
        ﹀秖 -= damageAmount;
        if (﹀秖 < 0)
        {
            ﹀秖 = 0;
        }
    }

    public void 獀隆(int healAmount)
    {
        ﹀秖 += healAmount;
        if (﹀秖 > 程﹀秖)
        {
            ﹀秖 = 程﹀秖;
        }
    }

}
