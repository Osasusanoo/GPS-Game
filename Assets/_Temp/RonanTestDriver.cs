using UnityEngine;

public class RonanTestDriver : MonoBehaviour
{
    public Entity entity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            entity.entityHealth.ChangeHealth(-15);
        }
    }
}
