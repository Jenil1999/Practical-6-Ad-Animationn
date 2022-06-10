using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public int MoveSpeed;
    bool IsRunning = false;
    public Joystick joystick;
    public Joystick CameraJoyStick;
    public CinemachineFreeLook camera1;
    public AudioSource audio1;
    //public AudioClip Lightning;





    //==========================================================================
    [Header("Jumpscare Setup")]
    //public Animation AnimationObject;
    public AudioClip JumpscareSound;
    [Range(0, 5)] public float scareVolume = 1f;
 

  
    public bool isPlayed;

    //========================================================================================================
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        var h = joystick.Horizontal;
        var v = joystick.Vertical;

        animator.SetFloat("Speed", v);

        animator.SetFloat("TurningSpeed", h);
        if(h!=0 || v !=0)
        {
            animator.SetBool("Running", false);
            IsRunning = false;
        }

        player.transform.Rotate(h * v * Vector3.up);

        camera1.m_XAxis.Value += CameraJoyStick.Direction.x;
        camera1.m_YAxis.Value -= CameraJoyStick.Direction.y / 100;
       
    }
   public void OnClickKick()
    {   
            animator.SetInteger("KickIndex", Random.Range(0, 3));
            animator.SetTrigger("Kick");
    }
    public void OnClickPunch()
    {   
            animator.SetInteger("PunchIndex", Random.Range(0, 2));
            animator.SetTrigger("Punch");
    } 
   
    public void OnClickjump()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            animator.SetTrigger("RunningJump");
        }
        else
        {
            animator.SetInteger("JumpIndex", Random.Range(0, 2));
            animator.SetTrigger("Jump");
        }
        animator.SetBool("Running", false);

    }

    public void OnclickRunning()
    {
        if(!(IsRunning))
        {
            animator.SetBool("Running",true);
            IsRunning = true;
        }
        else
        {
            animator.SetBool("Running", false);
            IsRunning = false;
        }
    }
    public void IsPlayed(bool state)
    {
        isPlayed = state;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trigger" && !isPlayed)
        {
          //  AnimationObject.Play();

            if (JumpscareSound)
            {
                audio1.PlayOneShot(JumpscareSound, scareVolume);
                /*PlayClip(JumpscareSound, scareVolume);*/
            }

            isPlayed = true;
        }
    }

    void PlayClip(AudioClip clip, float Volume)
    {
        if (clip != null)
        {
            Vector3 CameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, CameraPos, Volume);
        }
    }
    /*  private void OnTriggerEnter(Collider other)
      {
          Debug.Log("OnTriggerEnter : " + other.name);
      }
      private void OnCollisionEnter(Collision collision)
      {
          Debug.Log("OnCollisionEnter : " + collision.gameObject.name);
      }*/





 

   
    

    
}

