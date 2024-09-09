using System.Collections;
using System.Collections.Generic; // Aggiungi questo per usare List
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TypewriterEffect : MonoBehaviour
{
    public float delay = 0.1f;  // Ritardo tra la comparsa di ogni carattere
    private TextMeshProUGUI textMeshPro;
    private string fullText;
    private string currentText = "";
    public UnityEvent onEndTypeWritingEffect;
    public AudioSource typingLoop; // Aggiungi una lista di AudioSource

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        fullText = textMeshPro.text;
        textMeshPro.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        // Riproduci un suono casuale dalla lista
        typingLoop.Play();
        foreach (char letter in fullText.ToCharArray())
        {
            currentText += letter;
            textMeshPro.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        onEndTypeWritingEffect?.Invoke();
        typingLoop.Stop();
    }
}
