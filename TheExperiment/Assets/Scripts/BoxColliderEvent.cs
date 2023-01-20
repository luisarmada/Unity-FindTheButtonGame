using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxColliderEvent : MonoBehaviour
{

    //public bool isOpener = false;

    private bool isActive = true;

    //public GameObject doorAnimator;
    //public GameObject barrier;
    //public GameObject playSoundParent;

    public UnityEvent onCollide;
    public UnityEvent delayedEvent;
    public float delay = 2f;

    void OnTriggerEnter(Collider other)
    {

        if (isActive && other.tag == "Player")
        {
            //doorAnimator.GetComponent<Animator>().SetBool("open", isOpener);
            //barrier.SetActive(!isOpener);
            //playSoundParent.GetComponent<AudioSource>().Play();
            onCollide.Invoke();
            isActive = false;
            StartCoroutine(delayedEvents());
            //Destroy(gameObject);
        }

    }

    IEnumerator delayedEvents()
    {
        yield return new WaitForSeconds(delay);
        delayedEvent.Invoke();
    }
}
