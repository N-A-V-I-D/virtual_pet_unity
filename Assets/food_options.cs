using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class food_optons : MonoBehaviour
{
    private TextMeshProUGUI buttonText;
    public Animator animator;
    public Image health;
    public GameObject foodMenu;
    public float fillIncreaseAmount = 0.1f; 
    public float maxFill = 1.0f; 
    public float minFill = 0.0f; 
    public float lerpSpeed = 5f;
    private float targetFill; 
    public float scaleDuration = 1.0f;

    public void Initialize(Animator animator_food, Image healthImage, GameObject fm)
    {
        animator = animator_food;
        health = healthImage;
        foodMenu = fm;
    }
    
    void Start()
    {
        targetFill = health.fillAmount;
    }


    void Awake()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void btnClick()
    {
        if (buttonText != null)
        {
            Debug.Log("Button clicked: " + buttonText.text);
            eatingAnimation(buttonText.text);
        }
        else
        {
            Debug.Log("Button clicked, but no TextMeshProUGUI component found.");
        }
    }

    void eatingAnimation(string food)
    {
        switch(food)
        {
            case "Burger":
            animator.SetBool("eatingBurger", true);
            break;

            case "Hotdog":
            animator.SetBool("eatingHotdog", true);
            break;

            case "Pizza":
            animator.SetBool("eatingPizza", true);
            break;

            case "Fries":
            break;
        }
        Invoke("stop_eating", .3f);
        if(targetFill < maxFill){
            targetFill += fillIncreaseAmount;
            targetFill = Mathf.Clamp(targetFill, minFill, maxFill);
        }
        // foodMenu.SetActive(false);
    }

    public void stop_eating()
    {
        animator.SetBool("eatingBurger", false);
        animator.SetBool("eatingHotdog", false);
        animator.SetBool("eatingPizza", false);
    }

    void Update()
    {
        health.fillAmount = Mathf.Lerp(health.fillAmount, targetFill, lerpSpeed * Time.deltaTime);
    }
    
}


