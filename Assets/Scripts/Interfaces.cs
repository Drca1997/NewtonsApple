using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public interface IGameMode
{
    public bool OnTryEnd(ResultCode resultCode);
}
