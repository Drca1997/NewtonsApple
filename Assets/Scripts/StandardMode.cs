using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static Enums;

public class StandardMode : IGameMode
{
    public const int STANDARD_MODE_MAXIMUM_TRIES = 10;
    private GameHandler gameHandler;

    public StandardMode(GameHandler handler)
    {
        this.gameHandler = handler; 
    }

    public bool OnTryEnd(ResultCode resultCode)
    {
        if (gameHandler.Tries >= STANDARD_MODE_MAXIMUM_TRIES)
        {
            return false;
        }
        return true;
    }
}
