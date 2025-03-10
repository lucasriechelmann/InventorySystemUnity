using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewChangeCharPropertiesAction", menuName = "Action/New Change Char Properties Action")]
public class ChangeCharPropertiesActionScriptable : GenericActionScriptable
{
    #region Properties
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
    [Range(0, 10)]
    float _jump;
    [SerializeField]
    bool _applyNewGravity;
    [SerializeField]
    [Range(1f,4f)]
    float _gravity;
    [SerializeField]
    bool _applyNewPosition;
    [SerializeField]
    Vector3 _newPosition;
    [SerializeField]
    bool _resetJump;
    [SerializeField]
    bool _resetGravity;
    [SerializeField]
    bool _resetSpeed;
    #endregion
    #region Methods

    #endregion
    public override IEnumerator Execute()
    {
        yield return new WaitForSeconds(DelayToStart);

        if (_life != 0)
        {
            //GameController => Function to change life
        }

        if (_mana != 0)
        {
            //GameController => Function to change mana
        }

        if (_speed != 0)
        {
            //GameController => Function to change speed
        }

        if (_jump != 0)
        {
            //GameController => Function to change jump
        }
    }
}