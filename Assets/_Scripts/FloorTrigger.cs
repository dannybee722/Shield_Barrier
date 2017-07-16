using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrigger : MonoBehaviour {

    //transitions player from being on the first floor to the second in regards to rendering layer and sorting layer

    public int floorNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (floorNumber == 1)
            {
                //set player Layer to "BlockingLayer"
                collision.gameObject.layer = 8;

                collision.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Units";
            }

            if (floorNumber == 2)
            {
                //set player Layer to "BlockingLayer2"
                collision.gameObject.layer = 11;

                collision.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Units2";
            }
        }
    }
}
