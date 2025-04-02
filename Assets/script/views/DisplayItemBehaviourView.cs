using UnityEngine;

public class DisplayItemBehaviourView : MonoBehaviour
{
    #region Properties
    [SerializeField]
    GameObject _simpleSlotGo;
    [SerializeField]
    GameObject _complexSlotGo;
    #endregion
    #region Methods
    void OnEnable() => TurnOff();
    public void TurnOn() => _complexSlotGo.SetActive(true);
    public void TurnOff() => _complexSlotGo.SetActive(false);
    #endregion
}
