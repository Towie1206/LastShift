using System;
using UnityEngine;

public class WatcherAttack : MonoBehaviour
{
    [SerializeField] private Door rightDoor;
    [SerializeField] private float standDuration = 4f;
    private float timer;
    private bool isAttacking;

    public event Action Blocked;
    public event Action PlayerCaught;

    private void Update()
    {
        if (!isAttacking)
            return;

        if (!rightDoor.IsFullyClosed())
        {
            isAttacking = false;
            PlayerCaught?.Invoke();
            return;
        }

        timer += Time.deltaTime;

        if (timer < standDuration)
            return;

        isAttacking = false;
        Blocked?.Invoke();
    }


    public void BeginAttack()
    {
        if (rightDoor == null)
            return;

        timer = 0f;
        isAttacking = true;
    }
}
