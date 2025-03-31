using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragBehaviourView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    #region Properties
    CanvasGroup _canvasGroupdCg;
    GameObject _canvasIconGo;
    GameObject _iconGo;
    Sprite _iconImageSp;
    #endregion
    #region Methods
    void Awake()
    {
        _canvasGroupdCg = GetComponent<CanvasGroup>();
        _canvasIconGo = GameObject.FindGameObjectWithTag("CanvasIcone");
    }
    public void OnBeginDrag(PointerEventData eventData) => StartDrag();
    public void OnDrag(PointerEventData eventData)
    {
        _iconGo.transform.position = Input.mousePosition;
        _iconGo.gameObject.GetComponent<RectTransform>().pivot = new(0.5f, 0.5f);
    }
    public void OnEndDrag(PointerEventData eventData) => StopDrag();
    void StartDrag()
    {
        _iconGo = new GameObject("icon");
        Image image = _iconGo.AddComponent<Image>();
        CanvasGroup canvasGroup = _iconGo.AddComponent<CanvasGroup>();

        _iconImageSp = GetComponent<ComplexSlotView>().ItemView.Icon;

        image.sprite = _iconImageSp;
        image.raycastTarget = false;

        _iconGo.GetComponent<RectTransform>().sizeDelta = new(50, 50);
        _iconGo.transform.SetParent(_canvasIconGo.transform);
        canvasGroup.alpha = 0.65f;
    }
    void StopDrag()
    {
        Destroy(_iconGo, 0.05f);
    }
    #endregion
}
