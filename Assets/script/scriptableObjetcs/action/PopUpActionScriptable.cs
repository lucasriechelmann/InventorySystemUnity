using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPopUpAction", menuName = "Action/New Pop-Up Action")]
public class PopUpActionScriptable : GenericActionScriptable
{
    [SerializeField]
    [TextArea(5,8)]
    string _description;
    [SerializeField]
    Sprite _icon;
    [SerializeField]
    Color _textColor;
    [SerializeField]
    Color _backgroundColor;
    [SerializeField]
    [Range(0, 7)]
    float _timeToClosePopUp;
    public override IEnumerator Execute()
    {
        yield return new WaitForSeconds(DelayToStart);

        //GameController >> Show popup
    }
}
