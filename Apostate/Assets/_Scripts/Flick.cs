using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flick : MonoBehaviour
{
    Ray mouseRay;
    RaycastHit rcHit;
    int pokeForce = 1400;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(mouseRay, out rcHit))
            {
/*                print(rcHit.collider.name);
                if (rcHit.rigidbody != null)
                {
                    Vector3 massCenter = rcHit.rigidbody.worldCenterOfMass;
                    rcHit.rigidbody.AddForceAtPosition((massCenter - mouseRay.direction) * pokeForce, rcHit.point);
                }*/
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 dir = gameObject.transform.position - touchPos;
                rcHit.transform.SendMessage("Touched", dir);
                //GetComponent<Rigidbody>().AddForce(dir.normalized * pokeForce, ForceMode.Impulse);
                rcHit.rigidbody.AddForce(dir.normalized * pokeForce, ForceMode.Impulse);

            }
        }
    }
}