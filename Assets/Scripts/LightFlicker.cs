using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour
{
    public Light lightSource;  // La sorgente luminosa da far lampeggiare
    public float minIntensity = 0f;  // Intensità minima della luce
    public float maxIntensity = 1f;  // Intensità massima della luce
    public float flickerDuration = 1f;  // Durata totale del flicker in secondi
    public float finalIntensity = 1f;  // Intensità finale della luce
    public float[] flickerIntervals;  // Array di intervalli di flicker

    private void Start()
    {
        StartCoroutine(FlickerLight());
    }

    private IEnumerator FlickerLight()
    {
        float totalDuration = 0f;
        bool isMaxIntensity = false;

        while (totalDuration < flickerDuration)
        {
            foreach (float interval in flickerIntervals)
            {
                if (totalDuration >= flickerDuration)
                    break;

                // Alterna tra minIntensity e maxIntensity
                lightSource.intensity = isMaxIntensity ? maxIntensity : minIntensity;
                isMaxIntensity = !isMaxIntensity;
                yield return new WaitForSeconds(interval);
                totalDuration += interval;
            }
        }

        // Imposta l'intensità finale della luce
        lightSource.intensity = finalIntensity;
    }
}
