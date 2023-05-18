using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Instructor_Behaviour : MonoBehaviour
{
    public static Action OnModule1Completed;
    //AI
    public float stoppingRadius;
    [SerializeField] private Transform targetPlayer;
    [SerializeField] private DialogueManager dialogueManager;
    public NavMeshAgent agent;
    private Animator animator;
    private AiState currentAiState;
    public Transform target;

    private AudioSource audioSource;
    //Animation
    private int _animIDSpeed;
    private int _animIDGrounded;
    private int _animIDJump;
    private int _animIDFreeFall;
    private int _animIDMotionSpeed;

    public List<AudioClip> audioClips= new List<AudioClip>();


    void Start()
    {
        currentAiState = AiState.idle;
        agent = GetComponentInChildren<NavMeshAgent>();
        agent.stoppingDistance = stoppingRadius;
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        AssignAnimationIDs();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (currentAiState == AiState.tellCompleteGearupModule && !audioSource.isPlaying)
        {
            OnModule1Completed?.Invoke();
        }
    }

    public void WalkTo(Vector3 targetLocation)
    {
        agent.SetDestination(targetLocation);
    }

    private void AssignAnimationIDs()
    {
        _animIDSpeed = Animator.StringToHash("Speed");
        _animIDGrounded = Animator.StringToHash("Grounded");
        _animIDJump = Animator.StringToHash("Jump");
        _animIDFreeFall = Animator.StringToHash("FreeFall");
        _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
    }

    void Movement()
    {
        // If the AI is idle, don't move
        if (currentAiState == AiState.idle)
        {
            return;
        }

        // Make sure the AI agent stays within the stopping radius of the target player
        if (targetPlayer != null && Vector3.Distance(transform.position, targetPlayer.position) > stoppingRadius && currentAiState == AiState.approachplayer)
        {
            WalkTo(targetPlayer.position);
        }

        if(target != null && currentAiState == AiState.tellBoots)
        {
            Debug.Log("Walking towards targert");
            WalkTo(target.position);
        }
        /*else
        {
            agent.SetDestination(agent.transform.position);
        }*/

        // Update the animator's Speed parameter based on the agent's velocity
        animator.SetFloat(_animIDSpeed, agent.velocity.magnitude);
        animator.SetFloat(_animIDMotionSpeed, 1);

        // Rotate the agent in the direction of motion or face the target player when not moving
        if (agent.velocity.magnitude > 0)
        {
            Quaternion lookRotation = Quaternion.LookRotation(agent.velocity.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
        }
        else if (targetPlayer != null)
        {
            Vector3 direction = (targetPlayer.position - transform.position).normalized;
            direction.y = 0; // Prevent the AI instructor from tilting up or down
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
        }
    }

    public void changeAiState(AiState newState)
    {
        currentAiState = newState;
        Debug.Log(currentAiState);
    }
}