using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class feed_action : MonoBehaviour
{
    public Animator animator;
    public Image health;
    public float fillIncreaseAmount = 0.1f; // Amount to increase the fill amount by
    public float maxFill = 1.0f; // Maximum fill amount (100%)
    public float minFill = 0.0f; // Minimum fill amount (0%)
    public float lerpSpeed = 5f; // Speed of the lerping animation
    private float targetFill; // Target fill amount for lerping
    void Start()
    {
        targetFill = health.fillAmount;
    }

    // Update is called once per frame

    public void feed_burger(){
        // Debug.Log("Hello, Unity!");
        

        if (targetFill < maxFill)
        {
            animator.SetBool("eatingBurger", true);
            Invoke("stop_eating", .3f);
            targetFill += fillIncreaseAmount;
            targetFill = Mathf.Clamp(targetFill, minFill, maxFill); // Ensure targetFill stays within the bounds
        }
    }

    public void stop_eating(){
         animator.SetBool("eatingBurger", false);
    }
    void Update()
    {
        health.fillAmount = Mathf.Lerp(health.fillAmount, targetFill, lerpSpeed * Time.deltaTime);
    }
}
