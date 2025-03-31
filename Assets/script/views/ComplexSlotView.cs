using UnityEngine;
using UnityEngine.UI;

public class ComplexSlotView : MonoBehaviour
{
    #region Properties
    [SerializeField]
    GenericItemScriptable _itemView;
    [SerializeField]
    Image _icon;
    [SerializeField]
    Text _currentNumberText;
    CanvasGroup _canvasGroup;
    #endregion
    #region Getter and Setter
    public GenericItemScriptable ItemView
    {
        get => _itemView;
        set => _itemView = value;
    }
    #endregion
    #region Methods
    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public void UpdateText()
    {
        _currentNumberText.text = _itemView.CurrentNumber.ToString();
        EnableAndDisableIcon(_itemView.CurrentNumber);
    }
    public void UpdateIcon() => _icon.sprite = _itemView.Icon;
    void EnableAndDisableIcon(int value)
    {
        if(value > 0)
        {
            _canvasGroup.alpha = 1f;
            return;
        }

        _canvasGroup.alpha = 0.3f;
    }
    #endregion
}
