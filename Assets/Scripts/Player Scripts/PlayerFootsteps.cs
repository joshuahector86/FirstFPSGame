using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{

    private AudioSource footstep_sound;

    [SerializeField]
    private AudioClip[] footstep_clip;

    private CharacterController character_controller;

    [HideInInspector]
    public float volume_min, volume_max;

    private float accumlated_distance;

    [HideInInspector]
    public float step_distance;

    // Start is called before the first frame update
    void Awake()
    {
        footstep_sound = GetComponent<AudioSource>();

        character_controller = GetComponentInParent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckToPlayFootstepSound();
        
    }

    void CheckToPlayFootstepSound()
    {
        //If we are NOT on the ground
        if (!character_controller.isGrounded)
            return;

        //If we are on the ground
        if (character_controller.velocity.sqrMagnitude > 0)
        {
            /* Accumulated distance is the value how far we can go
             * e.g. make a step or sprint, or move while crouching
             * until we play the footstep sound
             */
            accumlated_distance += Time.deltaTime;

            if (accumlated_distance > step_distance)
            {
                footstep_sound.volume = Random.Range(volume_min, volume_max);
                footstep_sound.clip = footstep_clip[Random.Range(0, footstep_clip.Length)];
                footstep_sound.Play();

                accumlated_distance = 0f;


            }
        }else
        {
            accumlated_distance = 0f;
        }


    }//Check To Play Footstep Sound






}//class
