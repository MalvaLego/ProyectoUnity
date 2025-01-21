using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    //public float RotationSpeed= 1.0f;
    
    public CharacterController player;
    //private Rigidbody Physics;

    public float Speed= 1.0f;
    private Vector3 playerInput; 
    private Vector3 movePlayer;

    //Gravedad
    public float gravity=9.8f;
    public float fallVelocity;
    
    public bool isOnSlope=false;
    private Vector3 hitNormal;
    public float slideVelocity;
    public float slopeForceDown;

    //Skills
    public float JumpForce=1.0f;
    
    //Cámara
    public Camera mainCamera; 
    private Vector3 camForward;
    private Vector3 camRight;

    void Start()
    {
        //Cursor.lockState=CursorLockMode.Locked;
        //Cursor.visible=false;
        player= GetComponent<CharacterController>();
        //Physics=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        float horizontal= Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");
        
        playerInput= new Vector3(horizontal,0,vertical);
        playerInput= Vector3.ClampMagnitude(playerInput,1);

    
        //Cámara
        camDirection();
        movePlayer=playerInput.x*camRight+playerInput.z*camForward;
        player.transform.LookAt(player.transform.position+movePlayer);
        
        movePlayer=movePlayer*Speed;

        setGravity();

        playerSkills();

        player.Move(movePlayer*Time.deltaTime);

        //Rotacion
        //float rotationY=Input.GetAxis("Mouse X");
        //stransform.Rotate(new Vector3(0,rotationY*Time.deltaTime*RotationSpeed,0));

        //Salto
        //if (Input.GetKeyDown(KeyCode.Space)){
           //Physics.AddForce(new Vector3(0,JumpForce,0),ForceMode.Impulse); 
        //}
    }

    //
    void camDirection(){
        camForward=mainCamera.transform.forward;
        camRight=mainCamera.transform.right;

        camForward.y=0;
        camRight.y=0;

        camForward=camForward.normalized;
        camRight=camRight.normalized;
    }

    void playerSkills(){
        //Salto
        if ((Input.GetButtonDown("Jump")) && (player.isGrounded)){
           fallVelocity= JumpForce;
           movePlayer.y=fallVelocity;
        }
    }

    //Función para la gravedad
    void setGravity(){
        //movePlayer.y= -gravity*Time.deltaTime; // al multiplicar el deltatime otra vez aquí, no es 9.8 y genera una aceleración
        if (player.isGrounded){
            fallVelocity= -gravity*Time.deltaTime;
            movePlayer.y=fallVelocity;
        }else{
            fallVelocity -= gravity*Time.deltaTime;
            movePlayer.y=fallVelocity;
        }

        SlideDown();
    }

    public void SlideDown(){
        isOnSlope= Vector3.Angle(Vector3.up, hitNormal) >= player.slopeLimit && Vector3.Angle(Vector3.up, hitNormal) <= 89;

        if (isOnSlope)
        {
            movePlayer.x += ((1f-hitNormal.y) *hitNormal.x)*slideVelocity;
            movePlayer.z += ((1f-hitNormal.y) *hitNormal.z)*slideVelocity;
            movePlayer.y += slopeForceDown;
            // la multiplicación (1f-hitNormal.y) es para que dependiendo de la inclinación de la rampa de deslice a una velocidad o otra
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        hitNormal=hit.normal;    
    }

}