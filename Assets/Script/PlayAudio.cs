using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayAudio : MonoBehaviour
{

    [SerializeField] AudioSource as_AI;
    [SerializeField] AudioSource as_World;
    [SerializeField] AudioClip ac;
    [SerializeField] AI_Instructor_Behaviour aiInstructor;
    [SerializeField] GameObject target;
    [SerializeField] GameObject textUI;
    [SerializeField] VisualAuditory vs;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(1);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(2);
            AudioSource activeAs = as_AI.gameObject.activeInHierarchy ? as_AI : as_World;
            Debug.Log(activeAs);

            if(ac != null)
                StartCoroutine(playAudio(activeAs));

            if (aiInstructor != null)
            {
                aiInstructor.changeAiState(AiState.tellBoots);
                aiInstructor.agent.stoppingDistance = 0f;
                aiInstructor.target = target.transform;
            }

            if (textUI != null && vs.Visual)
                textUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (aiInstructor != null)
            {
                aiInstructor.gameObject.GetComponent<AI_Instructor_Behaviour>().changeAiState(AiState.approachplayer);
                aiInstructor.agent.stoppingDistance = aiInstructor.stoppingRadius;
            }

            if (textUI != null && vs.Visual)
                textUI.SetActive(false);
        }
    }

    IEnumerator playAudio(AudioSource activeAs)
    {
        Debug.Log(4);
        if (!activeAs.isPlaying)
        {
            Debug.Log(3);
            activeAs.clip = ac;
            activeAs.Play();
            ac = null;
            yield return null;
        }
        else
        {
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
