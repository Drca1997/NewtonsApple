using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Persistent Storage")]
public class SO_PersistentStorage : ScriptableObject
{
    public enum GameMode
    {
        NOT_DEFINED,
        STANDARD,
        SURVIVOR
    }

    public GameMode gameModeToPlay;

}
