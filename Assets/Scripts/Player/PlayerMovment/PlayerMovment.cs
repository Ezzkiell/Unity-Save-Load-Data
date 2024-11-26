using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    //C

    public float speed = 5f; 

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;

        transform.position += movement;
    }
}
