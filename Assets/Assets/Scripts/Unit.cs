using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Unit : MonoBehaviour
{
    private NavMeshAgent agent;

    [Header("Visuals")]
    [SerializeField] private GameObject selection;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        Deselect();
    }

    public void Select()
    {
        selection.SetActive(true);
    }

    public void Deselect()
    {
        selection.SetActive(false);
    }

    public void MoveTo(Vector3 destination)
    {
        agent.SetDestination(destination);
    }
}
