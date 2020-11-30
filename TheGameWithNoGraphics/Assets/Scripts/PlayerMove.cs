using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName; //Left and Right Keys
    [SerializeField] private string verticalInputName;//Up and Down
    [SerializeField] private float movementSpeed;

    
    [SerializeField] private float slopeForce;
    //This ray will check if we are on a slope
    [SerializeField] private float slopeForceRayLength;
    
    private CharacterController charController;
    

    private bool isJumping;

    //The tutorial says we are gonna use an AnimationCurve to specify how to jump
    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;

    private AudioSource audioSrc;


    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        audioSrc = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        PlayerMovement();
          if(Input.GetKeyDown(KeyCode.R))
                 Application.LoadLevel(4);
                 
        if((Input.GetAxis(horizontalInputName) != 0|| Input.GetAxis(verticalInputName) != 0) && !isJumping)
        {
            audioSrc.volume = Random.Range(0.5f, 1f);
            audioSrc.pitch = Random.Range(0.5f, 1.1f);
            
            if (!audioSrc.isPlaying)
            {
                audioSrc.Play();
                

            }
        }
        else
        {
            audioSrc.Stop();
        }
    }

    private void PlayerMovement()
    {
        float horiInput = Input.GetAxis(horizontalInputName);
        float vertInput = Input.GetAxis(verticalInputName);

        
        //Blue Arrow is always pointing Forward relative to the game object
        //Red Arrow is always pointing Right relative to the game object.
        //Manipulate these, and we got movement
        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horiInput;

        charController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f)  * movementSpeed);
        //ClampMagnitude helps clamp forward direction and right direct never go beyond the value of 1
        //Helps prevent diagonal movement to go faster than the other axis

        
        //Complicated bits of code that checks if we are on a slope or not
        //Its a bit weird, but the way it works is that we cast a raycast with OnSlope 
        //If the raycasts says we are on a slope, ,we force it down onto it.
        if ((vertInput != 0 || horiInput != 0) && OnSlope())
        {
            charController.Move(Vector3.down * charController.height / 2 * slopeForce * Time.deltaTime);
        }
        JumpInput();

    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;
        
        //Do While is a new form of...I think loops. But what to do is in the name so it should be simple.
        do
        {
            //Evaluate the Curve using timeInAir as the reference time
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);
        //charController.collisionFlags != CollisionFlags.Above means we check if we hit the ceilng or not

        charController.slopeLimit = 45.0f;
        isJumping = false;



    }

    //This method casts a ray to check if we are on a slope!
    private bool OnSlope()
    {
        if (isJumping)
        {
            return false;
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, charController.height / 2 * slopeForceRayLength))
        {
            if (hit.normal != Vector3.up)
            {
                return true;
            }
   
        }
        
        return false;
    }
}
