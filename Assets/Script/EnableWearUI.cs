using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWearUI : MonoBehaviour
{
    [SerializeField] GameObject mannequineUI;
    [SerializeField] GameObject listUI;
    [SerializeField] GameObject AI;

    private void OnTriggerEnter(Collider other)
    {
        mannequineUI.SetActive(true);
        listUI.SetActive(true);
        AI.SetActive(true);
        AI.GetComponent<AI_Instructor_Behaviour>().changeAiState(AiState.approachplayer);
    }
}
