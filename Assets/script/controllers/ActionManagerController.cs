
using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionManagerController : MonoBehaviour
{
    #region Properties
    [SerializeField]
    List<GenericActionScriptable> _currentActionList;
    #endregion
    #region Methods
    void OnEnable()
    {
        ActionManagerEvent.SendActionListEvent += ReceiveActionList;
    }
    void OnDisable()
    {
        ActionManagerEvent.SendActionListEvent -= ReceiveActionList;
    }
    void ReceiveActionList(List<GenericActionScriptable> actionListReceived)
    {
        if (actionListReceived is null || actionListReceived.Count == 0)
            return;

        _currentActionList.AddRange(actionListReceived);

        try
        {
            while(_currentActionList.Count > 0)
            {
                StopCoroutine(_currentActionList[0].Execute());
                StartCoroutine(_currentActionList[0].Execute());
                _currentActionList.RemoveAt(0);                
            }
        }
        catch(Exception ex)
        {
            Debug.LogError($"Error: {ex.Message}");
        }
    }
    #endregion
}
