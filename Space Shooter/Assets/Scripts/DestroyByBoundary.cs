using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    GameObject gameObject;

    private void OnTriggerExit(Collider other) {

        Destroy(other.gameObject);

    }

}
