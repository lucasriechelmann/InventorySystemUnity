using System.Collections;
using UnityEngine;

public abstract class GenericActionScriptable : ScriptableObject
{
    [SerializeField]
    [Range(0, 30)]
    float _delayToStart = 0;

    protected float DelayToStart => _delayToStart;
    public abstract IEnumerator Execute();
}
