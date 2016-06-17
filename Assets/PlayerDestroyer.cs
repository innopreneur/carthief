using UnityEngine;
using System.Collections;

public class PlayerDestroyer : MonoBehaviour {

    private bool isDead = false;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Car")
        {
            Destroy(gameObject);
            isDead = true;
            GameManager.instance.isPlayerDead = true;
        }

    }

}
