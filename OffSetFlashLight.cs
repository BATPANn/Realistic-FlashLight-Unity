using UnityEngine;

public class OffSetFlashLight : MonoBehaviour
{



    private Vector3 OffsetVect3; // the offset

    public GameObject FollowCam; // the camera

    [SerializeField] private float MoveSpeed = 13f; // move speed of the flashlight

    public Light Flashlight; // the flashlight

    private bool FlashLightIsOn = false; // to check if flashlight is on or off

    // audio

    public AudioSource Source; // play our audios

    public AudioClip FlashLight_OnSound;

    public AudioClip FlashLight_OffSound;


    // audio

    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        Flashlight.enabled = false;

        OffsetVect3 = transform.position - FollowCam.transform.position; // calculate the offset at the start

        
    }

    

    // Update is called once per frame
    void Update()
    {


        transform.position = FollowCam.transform.position + OffsetVect3; // add offset 

        transform.rotation = Quaternion.Slerp(transform.rotation, FollowCam.transform.rotation, MoveSpeed * Time.deltaTime); // change rotation with offset

        if (Input.GetKeyDown(KeyCode.F))
        {


            if(FlashLightIsOn == false)
            {

                Flashlight.enabled = true;
                FlashLightIsOn = true;

                // audio

                Source.PlayOneShot(FlashLight_OnSound);


                // audio



            }
            else if(FlashLightIsOn == true)
            {


                Flashlight.enabled = false;
                FlashLightIsOn = false;

                // audio


                Source.PlayOneShot(FlashLight_OffSound);

                // audio



            }



        }






        
    }
}
