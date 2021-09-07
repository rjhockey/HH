using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // collectibles & display
    public List<string> inventory;

    public Text count;  // drag text to be displayed onto this slot

    void Start()
    {
        inventory = new List<string>(); //could spec gameObject instead of string, more data intensive
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

            // send coin count screen
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
