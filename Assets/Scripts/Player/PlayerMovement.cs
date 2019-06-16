using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    void Awake() //mono-behavior function that unity called
    {
        //floor quadı floor layer'a koyduk we are going to get mask from floor
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }
    //unity call automatically
    //vertical w,s
    //horizontal a,d
    void FixedUpdate() //mono-behavior function that unity called
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        // Move the player around the scene.
        Move(h, v);

        // Turn the player to face the mouse cursor.
        //Turning();

        // Animate the player.
        Animating(h, v);
    }
    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;// delta time her update çağrısının arasındaki zamandır
        playerRigidbody.MovePosition(transform.position + movement);
    }
     //void Turning()
     // {
     //     Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
     //     RaycastHit floorHit;

     //     if(Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
     //     {
     //         // Create a vector from the player to the point on the floor the raycast from the mouse hit.
     //         Vector3 playerToMouse = floorHit.point - transform.position;

     //         // Ensure the vector is entirely along the floor plane.
     //         playerToMouse.y = 0f;
     //         // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
     //         Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
     //         // Set the player's rotation to this new rotation.
     //         playerRigidbody.MoveRotation(newRotation);
     //     }
     // }

    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;

        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
    }


}
