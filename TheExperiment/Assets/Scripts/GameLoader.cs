using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;

public class GameLoader : MonoBehaviour
{

    public GameObject player;
    public GameObject playerStartPos;
    public bool startGameFromStart = false;
    public bool testCanMoveAtStart = true;

    public GameObject contract;

    public GameObject Section1, Section2, Section3, Section4, Section5;

    public GameObject subtitles;

    public GameObject tooltipText;

    public GameObject introCanvas;
    public GameObject introText;

    public GameObject audioSource;
    public GameObject twodaudioSource;

    public AudioClip typewriterSFX;

    public List<AudioClip> voiceOvers = new List<AudioClip>();
    private int currentVoiceover = 0;

    void Start()
    {
        
        if(startGameFromStart)
        {
            StartCoroutine(introTypewrite());
            player.transform.position = playerStartPos.transform.position;
            player.transform.rotation = playerStartPos.transform.rotation;
            Cursor.lockState = CursorLockMode.Locked;
            if (!testCanMoveAtStart)
            {
                
                player.GetComponent<FirstPersonController>().canMove = false;
            }
            
            Section1.SetActive(true);
            Section2.SetActive(true);
            Section3.SetActive(false);
            Section4.SetActive(false);
            Section5.SetActive(false);
        }
    }

    public float typewriteSpeed = .4f;
    IEnumerator introTypewrite()
    {
        string[] introTextArray = { "As a broke college student, you decide to look for a job to fund your daily needs.",
        "As you were scrolling job posts, you found a one-day job which called for 'research subjects'.",
        "It paid lots of money.", "\"What can go wrong?\""};
        TMP_Text introTextMesh = introText.GetComponent<TMP_Text>();



        for(int i = 0; i < introTextArray.Length; i++)
        {
            string text = introTextArray[i];
            string currentText = "";
            for (int j = 0; j < text.Length; j++)
            {
                yield return new WaitForSeconds(typewriteSpeed);
                currentText = currentText + text[j];
                introTextMesh.SetText(currentText);
                twodaudioSource.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1f);
                twodaudioSource.GetComponent<AudioSource>().volume = 0.25f;
                twodaudioSource.GetComponent<AudioSource>().PlayOneShot(typewriterSFX);
               
            }
            yield return new WaitForSeconds(2f);
        }
        introCanvas.GetComponent<Animator>().enabled = true;
        StartCoroutine(StartupSequence());
        twodaudioSource.GetComponent<AudioSource>().pitch = 1f;
        twodaudioSource.GetComponent<AudioSource>().volume = 1f;
    }

    IEnumerator StartupSequence()
    {
        TMP_Text sbText = subtitles.GetComponent<TMP_Text>();

        subtitles.GetComponent<Animator>().SetBool("finished", false);
        sbText.SetText("Scientist: Sir? Are you listening?");
        audioSource.GetComponent<AudioSource>().PlayOneShot(voiceOvers[currentVoiceover]);
        yield return new WaitForSeconds(voiceOvers[currentVoiceover].length + speakingDelay);
        currentVoiceover++;
        subtitles.GetComponent<Animator>().SetBool("finished", true);

        yield return new WaitForSeconds(.15f);
        sbText.SetText("Scientist: Please do pay attention, this next part is very important.");
        subtitles.GetComponent<Animator>().SetBool("finished", false);
        yield return new WaitForSeconds(.15f);
        audioSource.GetComponent<AudioSource>().PlayOneShot(voiceOvers[currentVoiceover]);
        yield return new WaitForSeconds(voiceOvers[currentVoiceover].length + speakingDelay);
        currentVoiceover++;
        subtitles.GetComponent<Animator>().SetBool("finished", true);

        yield return new WaitForSeconds(.15f);
        sbText.SetText("Scientist: You must sign this contract before we let you continue.");
        subtitles.GetComponent<Animator>().SetBool("finished", false);
        yield return new WaitForSeconds(.15f);
        audioSource.GetComponent<AudioSource>().PlayOneShot(voiceOvers[currentVoiceover]);
        yield return new WaitForSeconds(voiceOvers[currentVoiceover].length + speakingDelay);
        currentVoiceover++;
        subtitles.GetComponent<Animator>().SetBool("finished", true);


        yield return new WaitForSeconds(.15f);
        sbText.SetText("Scientist: It's company procedure. No need to worry about the little details. Just sign it and we can proceed.");
        subtitles.GetComponent<Animator>().SetBool("finished", false);
        yield return new WaitForSeconds(.15f);
        audioSource.GetComponent<AudioSource>().PlayOneShot(voiceOvers[currentVoiceover]);
        yield return new WaitForSeconds(voiceOvers[currentVoiceover].length + speakingDelay);
        currentVoiceover++;
        subtitles.GetComponent<Animator>().SetBool("finished", true);

        contract.GetComponent<BoxCollider>().enabled = true;

        tooltipText.GetComponent<Animator>().SetBool("finished", false);
        tooltipText.GetComponent<TMP_Text>().SetText("[Press E on an object to interact]");
        yield return new WaitForSeconds(4f);
        tooltipText.GetComponent<Animator>().SetBool("finished", true);

    }

    public float speakingDelay = .5f;

    IEnumerator SignedContract()
    {
        tooltipText.GetComponent<Animator>().SetBool("finished", true);
        TMP_Text sbText = subtitles.GetComponent<TMP_Text>();

        yield return new WaitForSeconds(.15f);
        sbText.SetText("Scientist: Excellent. Now we can start the experiment.");
        subtitles.GetComponent<Animator>().SetBool("finished", false);
        yield return new WaitForSeconds(.15f);
        audioSource.GetComponent<AudioSource>().PlayOneShot(voiceOvers[currentVoiceover]);
        yield return new WaitForSeconds(voiceOvers[currentVoiceover].length + speakingDelay);
        currentVoiceover++;
        subtitles.GetComponent<Animator>().SetBool("finished", true);

        yield return new WaitForSeconds(.15f);
        sbText.SetText("Scientist: I've explained it before but I will explain it once more to make sure we are clear.");
        subtitles.GetComponent<Animator>().SetBool("finished", false);
        yield return new WaitForSeconds(.15f);
        audioSource.GetComponent<AudioSource>().PlayOneShot(voiceOvers[currentVoiceover]);
        yield return new WaitForSeconds(voiceOvers[currentVoiceover].length + speakingDelay);
        currentVoiceover++;
        subtitles.GetComponent<Animator>().SetBool("finished", true);

        yield return new WaitForSeconds(.15f);
        sbText.SetText("Scientist: The rules are simple. All you need to do is find the green button in each room.");
        subtitles.GetComponent<Animator>().SetBool("finished", false);
        yield return new WaitForSeconds(.15f);
        audioSource.GetComponent<AudioSource>().PlayOneShot(voiceOvers[currentVoiceover]);
        yield return new WaitForSeconds(voiceOvers[currentVoiceover].length + speakingDelay);
        currentVoiceover++;
        subtitles.GetComponent<Animator>().SetBool("finished", true);

        yield return new WaitForSeconds(.15f);
        sbText.SetText("Scientist: Then continue to the next room. Repeat this until the experiment is over.");
        subtitles.GetComponent<Animator>().SetBool("finished", false);
        yield return new WaitForSeconds(.15f);
        audioSource.GetComponent<AudioSource>().PlayOneShot(voiceOvers[currentVoiceover]);
        yield return new WaitForSeconds(voiceOvers[currentVoiceover].length + speakingDelay);
        currentVoiceover++;
        subtitles.GetComponent<Animator>().SetBool("finished", true);

        yield return new WaitForSeconds(.15f);
        sbText.SetText("Scientist: While you do this, we will be carefully monitoring your brain activity for use in our research.");
        subtitles.GetComponent<Animator>().SetBool("finished", false);
        yield return new WaitForSeconds(.15f);
        audioSource.GetComponent<AudioSource>().PlayOneShot(voiceOvers[currentVoiceover]);
        yield return new WaitForSeconds(voiceOvers[currentVoiceover].length + speakingDelay);
        currentVoiceover++;
        subtitles.GetComponent<Animator>().SetBool("finished", true);

        yield return new WaitForSeconds(.15f);
        sbText.SetText("Scientist: Of course, nothing harmful will come your way.");
        subtitles.GetComponent<Animator>().SetBool("finished", false);
        yield return new WaitForSeconds(.15f);
        audioSource.GetComponent<AudioSource>().PlayOneShot(voiceOvers[currentVoiceover]);
        yield return new WaitForSeconds(voiceOvers[currentVoiceover].length + speakingDelay);
        currentVoiceover++;
        subtitles.GetComponent<Animator>().SetBool("finished", true);

        yield return new WaitForSeconds(.15f);
        sbText.SetText("Scientist: Now with that sorted, why don't you try finding the green button hidden in this room to start.");
        subtitles.GetComponent<Animator>().SetBool("finished", false);
        yield return new WaitForSeconds(.15f);
        audioSource.GetComponent<AudioSource>().PlayOneShot(voiceOvers[currentVoiceover]);
        yield return new WaitForSeconds(voiceOvers[currentVoiceover].length + speakingDelay);
        currentVoiceover++;
        subtitles.GetComponent<Animator>().SetBool("finished", true);

        if (!testCanMoveAtStart)
        {
            player.GetComponent<FirstPersonController>().canMove = true;
        }
    }

    IEnumerator FoundButtonOne()
    {
        TMP_Text sbText = subtitles.GetComponent<TMP_Text>();
        subtitles.GetComponent<Animator>().SetBool("finished", false);
        sbText.SetText("Scientist: Great work. Please enter the door to your left and we will begin.");
        yield return new WaitForSeconds(.15f);
        audioSource.GetComponent<AudioSource>().PlayOneShot(voiceOvers[currentVoiceover]);
        yield return new WaitForSeconds(voiceOvers[currentVoiceover].length + speakingDelay);
        currentVoiceover++;
        subtitles.GetComponent<Animator>().SetBool("finished", true);

        yield return new WaitForSeconds(.15f);
        sbText.SetText("Scientist: If you are stuck, click on the megaphones in the room for a hint.");
        subtitles.GetComponent<Animator>().SetBool("finished", false);
        yield return new WaitForSeconds(.15f);
        audioSource.GetComponent<AudioSource>().PlayOneShot(voiceOvers[currentVoiceover]);
        yield return new WaitForSeconds(voiceOvers[currentVoiceover].length + speakingDelay);
        currentVoiceover++;
        subtitles.GetComponent<Animator>().SetBool("finished", true);

        yield return new WaitForSeconds(.15f);
        sbText.SetText("Scientist: However, they will only activate after a certain amount of time.");
        subtitles.GetComponent<Animator>().SetBool("finished", false);
        yield return new WaitForSeconds(.15f);
        audioSource.GetComponent<AudioSource>().PlayOneShot(voiceOvers[currentVoiceover]);
        yield return new WaitForSeconds(voiceOvers[currentVoiceover].length + speakingDelay);
        currentVoiceover++;
        subtitles.GetComponent<Animator>().SetBool("finished", true);
    }

    public void StartCoroutineByName(string name)
    {
        StartCoroutine(name);
    }

}
