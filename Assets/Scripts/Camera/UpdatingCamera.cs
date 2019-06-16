using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class UpdatingCamera : MonoBehaviour
{

   
    //BURDAN İTİBAREN
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
    //BURAYA KADAR
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);//sonradan eklendi
        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
        Animating(straffe, translation);
    }
    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;

        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
    }
}
//using UnityEngine;

//public class UpdatingCamera : MonoBehaviour {
//    public float speed = 10.0f;

//	// Use this for initialization
//	void Start () {
//        Cursor.lockState = CursorLockMode.Locked;
//	}

//	// Update is called once per frame
//	void Update () {
//        float translation = Input.GetAxis("Vertical") * speed;
//        float straffe = Input.GetAxis("Horizontal") * speed;
//        translation *= Time.deltaTime;
//        straffe*= Time.deltaTime;
//        transform.Translate(straffe, 0, translation);
//        if (Input.GetKeyDown("escape"))
//        {
//            Cursor.lockState = CursorLockMode.None;
//        }
//    }
//}