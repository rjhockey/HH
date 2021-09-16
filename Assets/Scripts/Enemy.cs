using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;

    void Start ()
    {
        GameObject tmp = Instantiate(enemy);
        Debug.Log("Enemy created");
        tmp.transform.position = new Vector2(20.0f, tmp.transform.position.y);
    }
}
