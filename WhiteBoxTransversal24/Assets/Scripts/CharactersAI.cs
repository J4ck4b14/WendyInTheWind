using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class CharactersAI : MonoBehaviour
{
    public GameObject reference;
    private NavMeshSurface surface;
    public char character;
    NavMeshAgent agent;
    public Transform waypoint;

    private void Awake()
    {
        character = this.name.ToCharArray()[0];
        this.GetComponent<NavMeshAgent>().speed = 1;
        this.GetComponent<NavMeshAgent>().radius = 0.75f;
        if (waypoint == null)
        {
            waypoint = GameObject.Find("Wapyoint").transform;
        }
        surface = reference.GetComponent<NavMeshSurface>();
    }

    // Start is called before the first frame update
    void Start()
    {
        switch (character)
        {
            case 'I':
                GetComponent<NavMeshAgent>().speed *= 0.9f;
                break;
            case 'N':
                GetComponent<NavMeshAgent>().speed *= 0.5f;
                break;
            case 'D':
                GetComponent<NavMeshAgent>().speed *= 0.7f;
                break;
            case 'E':
                GetComponent<NavMeshAgent>().speed *= 0.6f;
                break;
            case 'P':
                GetComponent<NavMeshAgent>().speed *= 0.8f;
                break;
            case 'A':
                GetComponent<NavMeshAgent>().speed *= 0.2f;
                break;
            case 'C':
                GetComponent<NavMeshAgent>().speed *= 0.5f;
                break;
            default:
                break;
        }
        this.surface.BuildNavMesh();

        Patrol();
    }

    void Patrol()
    {
        GetComponent<NavMeshAgent>().destination = waypoint.position;
    }
}
