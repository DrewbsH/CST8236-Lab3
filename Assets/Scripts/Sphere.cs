using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Sphere : MonoBehaviour {
    public int movementSpeed = 60;
    // Use this for initialization
    public Rigidbody rb;
    private Collider[] hitColliders;
    public float blastRadius;
    public float explosionPower;
    public LayerMask explosionLayers;
    public Transform wall;
    public AudioSource boom;
    public ParticleSystem explosion;
    
    void Start () {
        rb = GetComponent<Rigidbody>();
        blastRadius = 4.0f;
        explosionPower = 16.0f;
    }
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //print("Horizontal:" + moveHorizontal + " Vertical:" + moveVertical);
        Vector3 movement = new Vector3(moveHorizontal,0, moveVertical);
        rb.AddForce(movement * movementSpeed);
	}
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name != "Plane" && collision.gameObject.name != "Roof") 
        {
            Instantiate(explosion,gameObject.transform.position,Quaternion.identity);
            boom.Play();
            
            Boom(collision.contacts[0].point, collision.gameObject);
           
            //wall.TransformVector(collision.gameObject.transform.position);
        }
        

    }

    void Boom(Vector3 explosionPoint,GameObject wall)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius,explosionLayers);
        

        foreach (Collider hitCol in hitColliders)
        {
            if(hitCol.GetComponent<Rigidbody>() != null)
            {
                hitCol.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPoint, blastRadius, 1, ForceMode.Impulse);
            }
        }
    }
}
