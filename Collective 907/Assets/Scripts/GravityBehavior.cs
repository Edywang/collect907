using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Source for code:
* https://gamedev.stackexchange.com/questions/63545/how-to-change-gravity-towards-certain-object-in-unity
*/
public class GravityBehavior : MonoBehaviour
{
    public float RelativeWeight;
    // playerGravity is the vector of the force of gravity acting on the player
    public float playerGravity;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // We can add more moving objects here to assign relative weight
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        // offset squared between the object and the planet
        float masgqr;

        // offset of the distance to planet
        Vector3 offset;

        // get offset between each planet and the player
        offset = player.transform.position - transform.position;

        // Offset squared:
        masgqr = offset.sqrMagnitude;
        playerGravity = masgqr;
        
        /*
        // Check distance is more than 0 to prevent division by 0
        if (masgqr > 0.0001f) {
            // Create the gravity - make it realistic through division
            // by the "magsqr" variable
            GetComponent<Rigidbody>().AddForce(
                (RelativeWeight * offset.normalized / masgqr) 
                * GetComponent<Rigidbody>().mass
            );
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
