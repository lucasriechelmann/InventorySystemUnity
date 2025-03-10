using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlaySoundAction", menuName = "Action/New Play Sound Action")]
public class PlaySoundActionScriptable : GenericActionScriptable
{
    [SerializeField]
    AudioClip _audioFile;
    public override IEnumerator Execute()
    {
        yield return new WaitForSeconds(DelayToStart);

        if (_audioFile != null)
        {
            //GameController => Function to play sound            
        }
    }
}
