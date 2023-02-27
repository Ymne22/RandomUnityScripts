using UnityEngine;

public class AnimatorDisabler : MonoBehaviour
{
    [SerializeField] private float disableTime = 5f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    private void OnEnable()
    {
        Invoke(nameof(DisableAnimator), disableTime);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(DisableAnimator));
    }

    private void DisableAnimator()
    {
        animator.enabled = false;
    }
}