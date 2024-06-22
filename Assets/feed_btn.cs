using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class feed_action : MonoBehaviour
{
    public string[] textArray;
    public GameObject foodMenu;
    public GameObject outer_panel;
    public GameObject inner_panel;
    public Text textComponent;  
    public GameObject textMeshButtonPrefab;

    public Animator animator;
    public Image health;
    public float fillIncreaseAmount = 0.1f; 
    public float maxFill = 1.0f; 
    public float minFill = 0.0f; 
    public float lerpSpeed = 5f;
    private float targetFill; 
    public float scaleDuration = 1.0f;
    
    public TMP_FontAsset interFont;
    public GameObject buttonPrefab;

    public Vector3 targetScale = new Vector3(0.1f, 0.1f, 0.1f);
    void Start()
    {
        targetFill = health.fillAmount;
    }

    // Update is called once per frame

    public void feed_burger(){

        

        if (targetFill < maxFill)
        {
            // animator.SetBool("eatingBurger", true);
            // Invoke("stop_eating", .3f);
            // targetFill += fillIncreaseAmount;
            // targetFill = Mathf.Clamp(targetFill, minFill, maxFill); // Ensure targetFill stays within the bounds
        }
    }

    public void stop_eating()
    {
        animator.SetBool("eatingBurger", false);
    }

    void Update()
    {
        health.fillAmount = Mathf.Lerp(health.fillAmount, targetFill, lerpSpeed * Time.deltaTime);
    }

    public void showFoodOptions()
    {
        //foodMenu.SetActive(true);
        StartCoroutine(ScaleAndActivateCoroutine());
        
        string[] textArray = { "Burger", "Hotdog", "Pizza", "Fries"};
        float totalHeight = textArray.Length * 50f; 
        float startY = totalHeight / 2f - 25f;
        foreach (string text in textArray)
        {
    
            GameObject newButton = Instantiate(buttonPrefab, inner_panel.transform);
            TextMeshProUGUI newTextMeshPro = newButton.GetComponentInChildren<TextMeshProUGUI>();
            newTextMeshPro.text = text;
            newTextMeshPro.fontSize = 24;
            newTextMeshPro.font = interFont;
            newTextMeshPro.color = Color.black;
            newTextMeshPro.alignment = TextAlignmentOptions.Center;

            RectTransform rectTransform = newButton.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0f, startY);
            startY -= 50f; 

            Button buttonComponent = newButton.GetComponent<Button>();

            Animator buttonAnimator = newButton.GetComponent<Animator>();
            Image buttonHealthImage = newButton.GetComponent<Image>();
            GameObject buttonFoodMenu = newButton.GetComponent<GameObject>();
   
            buttonAnimator = animator;
            buttonHealthImage = health;
            buttonFoodMenu = foodMenu; 

            food_optons buttonScript = newButton.GetComponent<food_optons>();
            if (buttonScript != null)
            {
                buttonScript.Initialize(buttonAnimator, buttonHealthImage, buttonFoodMenu);
            }

        }  
     
    }

    IEnumerator ScaleAndActivateCoroutine()
    {
        foodMenu.SetActive(true);
        float elapsedTime = 0.0f;
        Vector3 initialScale = Vector3.zero;
        Vector3 targetScale = Vector3.one;

        while (elapsedTime < scaleDuration)
        {
            float t = elapsedTime / scaleDuration;
            outer_panel.transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            inner_panel.transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        outer_panel.transform.localScale = targetScale;
        inner_panel.transform.localScale = targetScale;
        Debug.Log("done");
    }
}
