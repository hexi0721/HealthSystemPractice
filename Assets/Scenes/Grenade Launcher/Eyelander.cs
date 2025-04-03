using UnityEngine;

public class Eyelander
{

    private const float BONUS_SPEED_PER_KILL = 1f;
    private const int BONUS_MAX_AMOUNT = 5;
    private static int bonusAmount = 1;

    public static void AddBonus()
    {
        if(bonusAmount < BONUS_MAX_AMOUNT)
        {
            bonusAmount++;
        }
    }

    public static void ResetBonus()
    {
        bonusAmount = 1;
    }

    public static float GetBonusSpeed()
    {
        return bonusAmount * BONUS_SPEED_PER_KILL;
    }



}
