using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ExplosionAction();
	}
	
	void ExplosionAction()
    {
        Destroy(gameObject, 2.5f);
    }
}
