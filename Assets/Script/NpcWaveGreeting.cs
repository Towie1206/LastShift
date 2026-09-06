using UnityEngine;

public class NpcWaveGreeting : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("PlayerPassed");
    }
}