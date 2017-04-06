using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagTrigger : MonoBehaviour {

    public GameManager gameManager { get; set; }

	void OnTriggerEnter(Collider coll)
    {
            if (coll.tag == "Player")
            {
                //gameManager.FlagTaken(tagPlayer);
                Destroy(this.gameObject);
            }

    }
}
