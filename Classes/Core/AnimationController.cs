using UnityEngine;

public class AnimationController
{
    public void ControlAnimator(Animator animator, float forward = 0f, float strafe = 0f, float aim = 11f)
    {
        animator.SetFloat("Forward", forward, 0.2f, 2 * Time.deltaTime);
        animator.SetFloat("Strafe", strafe, 0.2f, 2 * Time.deltaTime);

        if (aim > -10 && aim < 10)
        {
            animator.SetFloat("Aim", aim, 0.2f, 2 * Time.deltaTime);
        }
    }
    //animationController.ControlAnimator(animator, forward, strafe);
}
