using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioHandler : MonoBehaviour
{
    [SerializeField]
    AudioClip[] walkClips;
    AudioClip currentWalkClip;

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
    [SerializeField]
    AudioClip[] runClips;
    AudioClip currentRunClip;

    bool isPlayingWalkSound = false;
    bool isPlayingRunSound = false;
    AudioSource audioSource;
    
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayWalkSound()
    {
        if (!audioSource.isPlaying)
        {
            int rand = Random.Range(0, walkClips.Length);
            currentWalkClip = walkClips[rand];
            audioSource.clip = currentWalkClip;
            audioSource.Play();
        }
}


    private IEnumerator PlayWalkSoundCoroutine()
    {
        isPlayingWalkSound = true;
        int rand = Random.Range(0, walkClips.Length);
        currentWalkClip = walkClips[rand];
        audioSource.PlayOneShot(currentWalkClip);
        yield return new WaitForSeconds(currentWalkClip.length);
        isPlayingWalkSound = false;
    }

    public void StopWalkSound()
    {   
        if (audioSource.isPlaying && audioSource.clip == currentWalkClip)
        {
            audioSource.Stop();
        }
    }

    public void PlayRunSound()
    {
        if (!audioSource.isPlaying)
        {
            int rand = Random.Range(0, runClips.Length);
            currentRunClip = runClips[rand];
            audioSource.clip = currentRunClip;
            audioSource.Play();
        }
    }

    public void StopRunSound()
    {
        if (audioSource.isPlaying && audioSource.clip == currentRunClip)
        {
            audioSource.Stop();
        }
    }

    private IEnumerator PlayRunSoundCoroutine()
    {
        isPlayingRunSound = true;
        int rand = Random.Range(0, runClips.Length);
        currentRunClip = runClips[rand];
        audioSource.PlayOneShot(currentRunClip);
        yield return new WaitForSeconds(currentRunClip.length);
        isPlayingRunSound = false;
    }
}