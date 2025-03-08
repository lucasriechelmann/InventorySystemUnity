using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewChangeCharPropertiesAction", menuName = "Action/New Change Char Properties Action")]
public class ChangeCharPropertiesActionScriptable : GenericActionScriptable
{
    [SerializeField]
    [Range(-100, 100)]
    float _life;
    [SerializeField]
    [Range(-100, 100)]
    float _mana;
    [SerializeField]
    [Range(0, 4)]
    float _speed;
    [SerializeField]
    [Range(0,10)]
    float _jump;
    [SerializeField]
    bool _applyNewGravity;
    [SerializeField]
    Vector3 _newPosition;
    [SerializeField]
    bool _resetJump;
    [SerializeField]
    bool _resetGravity;
    [SerializeField]
    bool _resetSpeed;
    public override IEnumerator Execute()
    {
        yield return new WaitForSeconds(DelayToStart);

        //GameController >> Show popup
    }
}