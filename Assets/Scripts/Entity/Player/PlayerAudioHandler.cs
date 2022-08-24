using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sloth.Player
{
    public class PlayerAudioHandler : MonoBehaviour
    {
        // sound clips
        [SerializeField] AudioClip jumpSFX;
        [SerializeField] AudioClip collideSFX;
        [SerializeField] AudioClip runSFX;
        AudioSource audioSource;
        bool runAudioPlaying = false;
        bool crashAudioPlaying = false;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void Jump(bool isGrounded = false) {
            audioSource.PlayOneShot(jumpSFX);
        }

        public void Collide() {
            audioSource.Stop();
            if(!crashAudioPlaying)
                {
                    audioSource.PlayOneShot(collideSFX);
                    crashAudioPlaying = true;
                } 
            if(audioSource.isPlaying)
            {
                return;
            }
            crashAudioPlaying = false;
        }
        
        public void Run(bool isGrounded = false, bool isRunning = false) {
            if(isGrounded && isRunning && !audioSource.isPlaying) 
            {
                runAudioPlaying = true;
                audioSource.PlayOneShot(runSFX);
            } else if (runAudioPlaying && !isRunning)
            { 
                runAudioPlaying = false;
                audioSource.Stop();
            }

        }
    }
}