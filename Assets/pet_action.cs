using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pet_action : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public Image happiness;
    public float fillIncreaseAmount = 0.1f; // Amount to increase the fill amount by
    public float maxFill = 1.0f; // Maximum fill amount (100%)
    public float minFill = 0.0f; // Minimum fill amount (0%)
    public float lerpSpeed = 5f; // Speed of the lerping animation
    private float targetFill; // Target fill amount for lerping
    void Start()
    {
        targetFill = happiness.fillAmount;
    }

    public void pet(){
        if (targetFill < maxFill)
        {
            animator.SetBool("isPet", true);
            Invoke("stop_petting", .3f);
            targetFill += fillIncreaseAmount;
            targetFill = Mathf.Clamp(targetFill, minFill, maxFill); // Ensure targetFill stays within the bounds
            animator.SetFloat("stimulation", targetFill);
        }
        else{
            animator.SetBool("isAnnoyed", true);
            Invoke("stop_annoyed", .3f);
        }
    }

    public void stop_petting(){
        animator.SetBool("isPet", false);
    }

    public void stop_annoyed(){
        animator.SetBool("isAnnoyed", false);
    }

    // Update is called once per frame
    void Update()
    {
        happiness.fillAmount = Mathf.Lerp(happiness.fillAmount, targetFill, lerpSpeed * Time.deltaTime);
    }
}
