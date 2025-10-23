using UnityEngine;

public class Thisesting_script : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.ToString();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("This is a test comment");
    }

    void Update()
    {

    }
}
