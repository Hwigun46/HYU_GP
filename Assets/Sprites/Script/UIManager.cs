using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text count;
    public Image fillImage;
    public float maxHealth = 100f;
    private float currentHealth;
    private int needItem;
    private int getItem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        needItem = 5;
        getItem = 0;
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        count.text = getItem + "/" + needItem;
        UpdateHealthBar();
    }
    void UpdateHealthBar()
    {
        if (fillImage != null)
        {
            fillImage.fillAmount = currentHealth / maxHealth;
        }
    }
    public void GetItem()
    {
        if (getItem < needItem)
        {
            getItem++;
        }
    }

    public void Damage()
    {
        currentHealth = Mathf.Clamp(currentHealth - 20f, 0, maxHealth);
    }
}
