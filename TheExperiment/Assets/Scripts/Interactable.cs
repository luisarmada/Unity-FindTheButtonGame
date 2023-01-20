using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    public UnityEvent onInteract;
    public bool oneTimeInteractable = false;
    public bool hasBeenInteractedWith = false;
    public bool toggleInteract = false;
    public UnityEvent onInteractEvent2;

    public UnityEvent delayInteract;
    public float delay = .5f;
}
