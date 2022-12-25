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

   public IEnumerator PlayWalkSound(bool isWalking)
    {
         // Check if the player is still walking
        if (isWalking)
        {
            // If the player is not walking, stop the audio clip
            audioSource.Stop();
            yield return null;
        }
        int rand = Random.Range(0, walkClips.Length);
        AudioClip clip = walkClips[rand];

        audioSource.PlayOneShot(clip);
        Debug.Log("Playing walk sound");

        yield return new WaitForSeconds(clip.length);

        // Call the function again after the clip finishes playing
        StartCoroutine(PlayWalkSound(isWalking));
}
    
}
