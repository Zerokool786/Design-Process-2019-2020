using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class FPSController : MonoBehaviour {

    public float Speed = 2f;
    CharacterController Player;
    public AudioSource Footsteps;
    

    float moveBF;
    float moveRL;
	// Use this for initialization
	void Start () {

        Player = GetComponent<CharacterController>();
        
	}
	
	// Update is called once per frame
	void Update () {

        moveBF = Input.GetAxis("Vertical") * Speed;
        moveRL = Input.GetAxis("Horizontal") * Speed;

        Vector3 motion = new Vector3(moveRL, 0, moveBF);
        motion = transform.rotation * motion;

        Player.Move(motion * Time.deltaTime);
        

    }

    private void FixedUpdate()
    {
        PlayFootsteps();
    }

    private void PlayFootsteps()
    {
        if(moveBF > 0.1f && moveBF < Speed + 0.1f)
        {
            Footsteps.enabled = true;
            Footsteps.loop = true;
            Footsteps.Play();

        }

        if (moveBF < 0.1f)
        {

            Footsteps.loop = false;

        }
    }
}
