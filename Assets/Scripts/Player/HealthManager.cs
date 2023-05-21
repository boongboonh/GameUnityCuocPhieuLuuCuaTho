using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HealthManager : MonoBehaviour
{
    public int Maxhealth = 3;
    public int health = 0;

    public RectTransform pointHealth;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    private List<Image> healthImages = new List<Image>();

    public static HealthManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        health = Maxhealth;
    }

    private void Start()
    {
        for (int i = 0; i < Maxhealth; i++)
        {
            GameObject newObj = new GameObject();
            Image newImage = newObj.AddComponent<Image>();
            newImage.sprite = null;
            newObj.GetComponent<RectTransform>().SetParent(pointHealth.transform);
            healthImages.Add(newImage);
        }

        ResetUIHealth();
    }

    public void ResetUIHealth()
    {
        foreach (Image image in healthImages)
        {
            image.sprite = emptyHeart;
        }

        for (int i = 0; i < health; i++)
        {
            healthImages[i].sprite = fullHeart;
        }
    }
}
