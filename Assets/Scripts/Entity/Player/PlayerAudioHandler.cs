using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioHandler : MonoBehaviour
{
    [SerializeField]
    AudioClip[] walkClips;

    [SerializeField]
    AudioClip[] jumpClips;

    [SerializeField]
    AudioClip[] landClips;

    [SerializeField]
    AudioClip[] deathClips;

    [SerializeField]
    AudioClip[] attackClips;

    [SerializeField]
    AudioClip[] hurtClips;

    AudioSource audioSource;
    
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    bool isPlayingWalkSound = false;
   public void PlayWalkSound()
    {
        if (!isPlayingWalkSound)
        {
            StartCoroutine(PlayWalkSoundCoroutine());
        }
    }

    private IEnumerator PlayWalkSoundCoroutine()
    {
        isPlayingWalkSound = true;
        int rand = Random.Range(0, walkClips.Length);
        AudioClip clip = walkClips[rand];
        audioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        isPlayingWalkSound = false;
    }
}