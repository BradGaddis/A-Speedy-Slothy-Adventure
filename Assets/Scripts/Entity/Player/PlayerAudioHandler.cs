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
    AudioClip currentJumpClip;

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
    AudioSource audioSource;

    // component references
    PlayerState playerState;


    // check if jump is playing
    bool isPlayingJumpSound = false;

    bool isPlayingWalkSound = false;
    bool isPlayingRunSound = false;
    
    private void Start() {
        audioSource = GetComponent<AudioSource>();
        playerState = GetComponent<PlayerState>();
    }

    private void Update() {
        // check if player is in walking state
        if (playerState.CurrentState == PlayerStateType.Walk)
        {
            PlayWalkSound();
        }
        else
        {
            StopWalkSound();
        }

        // check if player is in running state
        if (playerState.CurrentState == PlayerStateType.Run)
        {
            PlayRunSound();
        }
        else
        {
            StopRunSound();
        }

        // check if player is in jumping state
        if (playerState.CurrentState == PlayerStateType.Jump)
        {
            PlayJumpSound();
        } else{
            isPlayingJumpSound = false;
        }

    }

    private void PlayWalkSound()
    {
        
        if (isPlayingWalkSound){
            return;
        }
        if (!audioSource.isPlaying)
        {
            int rand = Random.Range(0, walkClips.Length);
            currentWalkClip = walkClips[rand];
            audioSource.clip = currentWalkClip;
            audioSource.Play();
        }
    }
    


    private void PlayRunSound()
    {
        if (isPlayingRunSound)
        {
            return;
        }

        if (!audioSource.isPlaying)
        {
            int rand = Random.Range(0, runClips.Length);
            currentRunClip = runClips[rand];
            audioSource.clip = currentRunClip;
            audioSource.Play();
        }
    }

    private void StopWalkSound()
    {
        if (audioSource.isPlaying && audioSource.clip == currentWalkClip)
        {
            audioSource.Stop();
        }
    }

    private void StopRunSound()
    {
        if (audioSource.isPlaying && audioSource.clip == currentRunClip)
        {
            audioSource.Stop();
        }
    }

    public void PlayJumpSound()
    {
        Debug.Log("Playing jump sound " + isPlayingJumpSound);
        // check if playing
        if (isPlayingJumpSound)
        {
            return;
        } 
        isPlayingJumpSound = true;
        // Stop running and walking sounds
        if (audioSource.isPlaying)
        {
                StopRunSound();
                StopWalkSound();
        }
        int rand = Random.Range(0, jumpClips.Length);
        currentJumpClip = jumpClips[rand];

        audioSource.clip = currentJumpClip;

        audioSource.PlayOneShot(currentJumpClip);
        
    }


    public void StopJumpSound()
    {
        if (audioSource.isPlaying && audioSource.clip == currentJumpClip)
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