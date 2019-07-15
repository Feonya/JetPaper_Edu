using UnityEngine;

public class PlayersSoundsController : MonoBehaviour
{
    private StateMachine stateMachine;

    private AudioSource jumpSound;
    private AudioSource blowSound;
    private AudioSource deadSound;
    private AudioSource infatuateSound;
    private AudioSource vomitSound;

    private bool isJumpSoundPlayed;
    private bool isBlowSoundPlayed;
    private bool isDeadSoundPlayed;
    private bool isInfatuateSoundPlayed;
    private bool isVomitSoundPlayed;

    private void Start()
    {
        stateMachine = GameObject.FindGameObjectWithTag("Player").GetComponent<StateMachine>();

        jumpSound = transform.GetChild(0).GetComponent<AudioSource>();
        blowSound = transform.GetChild(1).GetComponent<AudioSource>();
        deadSound = transform.GetChild(2).GetComponent<AudioSource>();
        infatuateSound = transform.GetChild(3).GetComponent<AudioSource>();
        vomitSound = transform.GetChild(4).GetComponent<AudioSource>();

        isJumpSoundPlayed = false;
        isBlowSoundPlayed = false;
        isDeadSoundPlayed = false;
        isInfatuateSoundPlayed = false;
        isVomitSoundPlayed = false;
    }

    private void FixedUpdate()
    {
        PlayJumpSound();
        PlayBlowSound();
        PlayDeadSound();
        PlayInfatuateSound();
        PlayVomitSound();
    }

    private void PlayJumpSound()
    {
        if (stateMachine.state == StateMachine.States.Jump)
        {
            if (!isJumpSoundPlayed)
            {
                jumpSound.Play();
                isJumpSoundPlayed = true;
            }
        }
        else
        {
            if (isJumpSoundPlayed)
            {
                isJumpSoundPlayed = false;
            }
        }
    }

    private void PlayBlowSound()
    {
        if (stateMachine.state == StateMachine.States.Blow)
        {
            if (!isBlowSoundPlayed)
            {
                blowSound.Play();
                isBlowSoundPlayed = true;
            }
        }
        else
        {
            if (isBlowSoundPlayed)
            {
                isBlowSoundPlayed = false;
            }
        }
    }

    private void PlayDeadSound()
    {
        if (stateMachine.state == StateMachine.States.Dead)
        {
            if (!isDeadSoundPlayed)
            {
                deadSound.Play();
                isDeadSoundPlayed = true;
            }
        }
        else
        {
            if (isDeadSoundPlayed)
            {
                isDeadSoundPlayed = false;
            }
        }
    }

    private void PlayInfatuateSound()
    {
        if (stateMachine.state == StateMachine.States.Infatuate)
        {
            if (!isInfatuateSoundPlayed)
            {
                infatuateSound.Play();
                isInfatuateSoundPlayed = true;
            }
        }
        else
        {
            if (isInfatuateSoundPlayed)
            {
                isInfatuateSoundPlayed = false;
            }
        }
    }

    private void PlayVomitSound()
    {
        if (stateMachine.state == StateMachine.States.Vomit)
        {
            if (!isVomitSoundPlayed)
            {
                vomitSound.Play();
                isVomitSoundPlayed = true;
            }
        }
        else
        {
            if (isVomitSoundPlayed)
            {
                isVomitSoundPlayed = false;
            }
        }
    }
}
