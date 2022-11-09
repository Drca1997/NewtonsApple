using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class SurvivorMode : IGameMode
{
    private GameHandler gameHandler;
    public SurvivorMode(GameHandler handler)
    {
        this.gameHandler = handler; 
    }

    public bool OnTryEnd(ResultCode resultCode)
    {
        if (resultCode == ResultCode.DEFEAT)
        {
            return false;
        }
        return true;
    }

}
