using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    private void Reset() {
        GetComponent<PolygonCollider2D>().isTrigger = true;
    }
    public abstract void Interact();

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) other.GetComponent<PlayerMovement>().OpenInteractIcon();
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) other.GetComponent<PlayerMovement>().CloseInteractIcon();
    }

}
