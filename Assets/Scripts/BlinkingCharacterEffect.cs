using System.Collections;
using TMPro;
using UnityEngine;

public class BlinkingCharacterEffect : MonoBehaviour
{
    public int characterIndex = 0;  // L'indice del carattere che vuoi far lampeggiare
    public float blinkInterval = 0.5f;  // Intervallo di tempo tra comparsa e scomparsa

    private TextMeshProUGUI textMeshPro;
    private string fullText;
    private bool isBlinking = false;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        fullText = textMeshPro.text;
        StartBlinking();
    }

    public void StartBlinking()
    {
        if (!isBlinking)
        {
            isBlinking = true;
            StartCoroutine(BlinkCharacter());
        }
    }

    public void StopBlinking()
    {
        isBlinking = false;
    }

    IEnumerator BlinkCharacter()
    {
        while (isBlinking)
        {
            if (characterIndex == -1)
            {
                // Lampeggia l'intero testo
                textMeshPro.text = "";
                yield return new WaitForSeconds(blinkInterval);

                textMeshPro.text = fullText;
                yield return new WaitForSeconds(blinkInterval);
            }
            else
            {
                // Lampeggia un singolo carattere
                string newText = fullText;
                newText = newText.Remove(characterIndex, 1);
                textMeshPro.text = newText;
                yield return new WaitForSeconds(blinkInterval);

                textMeshPro.text = fullText;
                yield return new WaitForSeconds(blinkInterval);
            }
        }
    }
}
