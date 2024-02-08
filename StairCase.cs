using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaircaseTrigger : MonoBehaviour
{
    public GameObject fps;
    public GameObject trigger;
    private void OnTriggerEnter(Collider other)
    {
        fps.GetComponent<FPSMovement>().MoveLocked();
        fps.GetComponent<MoveUp>().isStaircase = true;
        Destroy(trigger);
    }
}
