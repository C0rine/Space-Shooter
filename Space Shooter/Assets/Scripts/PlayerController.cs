using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {

    public float xMin, xMax, zMin, zMax;

}


public class PlayerController : MonoBehaviour {

    private Rigidbody rigidBody;
    public float speed;
    public float tilt;
    public float turn;
    public float dip;
    public Boundary boundary;
    public float fireRate = 0.5F;
    private float nextFire = 0.0f;
    

    public GameObject shot;
    public Transform shotSpawn;

    private void FixedUpdate() {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rigidBody = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rigidBody.velocity = movement * speed;

        rigidBody.position = new Vector3(Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(rigidBody.position.z, boundary.zMin, boundary.zMax));
        rigidBody.rotation = Quaternion.Euler(rigidBody.velocity.z * dip, rigidBody.velocity.x * turn, rigidBody.velocity.x * -tilt);

    }

    private void Update() {

        if(Input.GetButton("Fire1") && Time.time > nextFire) {

            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
         
        }

    }

}
