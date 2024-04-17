using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSoundEmitter : MonoBehaviour
{
   public void PlayBirdSounds()
    {
        AudioManager.Instance.PlayOneSHot(FMODEvents.Instance.BirdIntro, this.transform.position);
    }
}
