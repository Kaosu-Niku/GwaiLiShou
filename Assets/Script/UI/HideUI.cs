using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideUI : MonoBehaviour
{
    [SerializeField] float ColorAlpha;
    [SerializeField] List<Image> AllImage = new List<Image>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int x = 0; x < AllImage.Count; x++)
                AllImage[x].color = new Color(AllImage[x].color.r, AllImage[x].color.g, AllImage[x].color.b, ColorAlpha);

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int x = 0; x < AllImage.Count; x++)
                AllImage[x].color = new Color(AllImage[x].color.r, AllImage[x].color.g, AllImage[x].color.b, 1);
        }
    }
}
