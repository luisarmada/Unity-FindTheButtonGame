using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    public LayerMask interactableLayermask = 6;
    UnityEvent onInteract;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool interactFlag = true;
    private bool canInteract = true;

    public Image interactIcon;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayermask))
        {
            if (hit.collider.GetComponent<Interactable>() != null
                && !(hit.collider.GetComponent<Interactable>().oneTimeInteractable && hit.collider.GetComponent<Interactable>().hasBeenInteractedWith))
            {
                canInteract = true;
            } else
            {
                canInteract = false;
            }
        } else
        {
            canInteract = false;
        }

        interactIcon.enabled = canInteract;

        if (canInteract && Input.GetKeyDown(KeyCode.E) && interactFlag)
        {
            Interactable interactScript = hit.collider.GetComponent<Interactable>();

            canInteract = false;
            if (!interactScript.toggleInteract) // if normal interact
            {
                interactScript.onInteract.Invoke();
                interactScript.hasBeenInteractedWith = true;
            }
            else // if toggle interact
            {
                if (interactScript.hasBeenInteractedWith) // check which state
                {
                    interactScript.onInteractEvent2.Invoke();
                    interactScript.hasBeenInteractedWith = false;
                }
                else
                {
                    interactScript.onInteract.Invoke();
                    interactScript.hasBeenInteractedWith = true;
                }
            }

            StartCoroutine(delayedEvent(interactScript));

        }

        if(!interactFlag && !Input.GetKeyDown(KeyCode.E)){
            interactFlag = true;
        }
        
        IEnumerator delayedEvent(Interactable interactScript)
        {
            yield return new WaitForSeconds(interactScript.delay);
            interactScript.delayInteract.Invoke();
        }

    }
}
