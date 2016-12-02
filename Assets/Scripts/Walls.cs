using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Walls : MonoBehaviour {

    
    public Transform wall;


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Sphere")
        {
            print(collision.gameObject.name);
            Transform bleh = gameObject.transform;
            Destroy(gameObject);
            Instantiate(wall,bleh.position,bleh.rotation);
            //wall.transform.position = bleh.position;
            //wall.transform.rotation = bleh.rotation;
            //wall.transform.TransformVector(collision.gameObject.transform.position);
            
            
        }
    }
}
