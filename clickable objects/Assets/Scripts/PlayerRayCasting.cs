using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCasting : MonoBehaviour {
    RaycastHit whatIHit;
    public float distanceToSee;
    public GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.green);

        if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit , distanceToSee)) //needs to hit something to move to next if statement and key E is pressed
        {
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              Debug.Log("I picked up a" + whatIHit.collider.gameObject.name);
                if (whatIHit.collider.tag == "Keycards")
                {
                    if (whatIHit.collider.gameObject.GetComponent<KeyCards>().whatKeyAmI == KeyCards.Keycards.redKey) //if raycast hits collider store in Keycards get access to the game component
                    {
                       player.GetComponent<Inventory>().hasredKey = true; //error null reference
                        Destroy(whatIHit.collider.gameObject);
                    }
                }

                if (whatIHit.collider.tag == "Doors")
                {
                    if (whatIHit.collider.gameObject.GetComponent<DoorManager>().whatDoorAmI == DoorManager.Doors.RedDoor) //if raycast hits collider store in Keycards get access to the game component
                    {
                        if (player.GetComponent<Inventory>().hasredKey == true)
                        {
                            player.GetComponent<Inventory>().hasredKey = false; //don't trigger opening door again once it's been done
                            Destroy(whatIHit.collider.gameObject);
                        }

                        else
                        {
                            Debug.Log("Find the redKey! ");
                        }
                       
                    }
                }


            }
            
        }
	}
}
