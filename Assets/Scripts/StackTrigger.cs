using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Points")
        {
            StackManager.instance.PickUp(other.gameObject, true, "Untagged");
            //StackManager.instance.Stairs(other.gameObject, true, "Untagged");
        }
    }
}
