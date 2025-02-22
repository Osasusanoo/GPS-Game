using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float rotateSpeed = 360f;
    public float rotation;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.MoveRotation(rotation);
        rotation += rotateSpeed * Time.deltaTime;
    }
}
