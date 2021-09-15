using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float xMin = -2.9f, yMin = -3.5f, xMax = 2.9f, yMax = 5.5f;
}

public class PlayerController : MonoBehaviour
{
    

    Rigidbody physic;
    public Boundary boundary;

    [SerializeField]float speed = 10f;
    [SerializeField] GameObject shot, shotSpawn;
    [SerializeField] float nextFire, fireRate;
    

    void Start()
    {
        physic = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
        }

    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal * speed, moveVertical * speed, 0f);
        Vector3 position = new Vector3(
            Mathf.Clamp(physic.position.x,boundary.xMin,boundary.xMax),
            Mathf.Clamp(physic.position.y, boundary.yMin, boundary.yMax),
            0f);
        physic.velocity = movement;
        physic.position = position;

        physic.rotation = Quaternion.Euler(-90f,physic.velocity.x*-3f, 0f);

    }
}
