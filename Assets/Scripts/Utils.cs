using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    
    public static bool IsSurvivorMode()
    {
        return GameAssets.Instance.Storage.gameModeToPlay == Enums.GameModeCode.SURVIVOR;
    }
}
