using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlaySoundAction", menuName = "Action/New Play Sound Action")]
public class PlaySoundActionScriptable : GenericActionScriptable
{
    public override IEnumerator Execute()
    {
        yield return new WaitForSeconds(DelayToStart);

        //GameController >> Show popup
    }
}
