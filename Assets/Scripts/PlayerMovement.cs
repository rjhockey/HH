using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // collectibles & display
    public List<string> inventory;

    public Text count;
    public Text lives;

    public int life = 0;

    // player movement
    public CharacterController2D controller; //in Unity drag the CharacterController script into this slot
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Start()
    {
        inventory = new List<string>(); //could spec gameObject instead of string, more data intensive
    }

    // Update is called once per frame
    void Update()
    {
        //Gets player input as -1 or 1 ie a or left arrow is -
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) //Jump = spacebar as spec by Input Manager
        {
            jump = true; // pass this into FixedUpdate controller.Move...below
        }
        //will only work if you animate this action
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true; // pass this into FixedUpdate controller.Move...below
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    //Updates mult. times per frame
    private void FixedUpdate()
    {
        //Moves player...direction, crouching, jumping
        //Time.fix... is amount of time elapsed since last time function was called
        //creates consistent speed on all platforms regardless of #times called
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        //reset to prevent neverending jump
        jump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            // collect the item
            string itemType = collision.gameObject.GetComponent<Collectibles>().itemType;
            // to test
            Debug.Log("I have collected a " + itemType); 

            // place collected item into list
            inventory.Add(itemType);
            //to test
            Debug.Log("Numbers of items in inventory List: " + inventory.Count);

            // send coin count to screen
            count.text = ("Coins " + inventory.Count.ToString());
            Destroy(collision.gameObject);
        }

        else if (collision.CompareTag("Next"))
        {
            //Moves to next scene/level on completion tied to UnityEngine.SceneManagement
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //moved to own function below
            StartCoroutine(LoadNextScene());
        }
    }

    public IEnumerator LoadNextScene()
    {
        // use to delay start of next scene, 0 = no delay
        yield return new WaitForSeconds(0f); 
        // moves to next scene/level on completion tied to UnityEngine.SceneManagement
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}