using System.Collections;
using TMPro;
using UnityEngine;
/// <summary>
/// A collection of graphical effects.
/// </summary>
public class Effects : MonoBehaviour
{
    #region Fade Function Overloads
    /// <summary>
    /// Fades the given CanvasGroup in or out by a specified duration.
    /// </summary>
    /// <param name="canvasGroup">The canvasGroup to apply fading to</param>
    /// <param name="fadeMode">An enum with the options of IN and OUT</param>
    /// <param name="duration">Time in seconds</param>
    /// <param name="useUnscaled"></param>
    /// <returns></returns>
    public static IEnumerator Fade(CanvasGroup canvasGroup, FadeMode fadeMode, float duration, bool useUnscaled)
    {
        if(useUnscaled == false)
        {
            Debug.LogError("The boolean is unnecessary if its set to false, please call this method WITHOUT the boolean.");
            yield break;
        }
        float startingValue = 0;
        float endingValue = 0;
        if (FadeModeChecker(fadeMode, ref startingValue, ref endingValue) == false)
        {
            yield break;
        }

        float count = 0;
        while (count < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startingValue, endingValue, count / duration);
            count += Time.unscaledDeltaTime;
            yield return null;
        }
    }

    public static IEnumerator Fade(CanvasGroup canvasGroup, FadeMode fadeMode, float duration)
    {
        float startingValue = 0;
        float endingValue = 0;
        if (FadeModeChecker(fadeMode, ref startingValue, ref endingValue) == false)
        {
            yield break;
        }

        float count = 0;
        while (count < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startingValue, endingValue, count / duration);
            count += Time.deltaTime;
            yield return null;
        }
    }

    public static IEnumerator Fade(TextMeshProUGUI textMesh, FadeMode fadeMode, float duration)
    {
        float startingValue = 0;
        float endingValue = 0;
        if (FadeModeChecker(fadeMode, ref startingValue, ref endingValue) == false)
        {
            yield break;
        }

        float count = 0;
        while (count < duration)
        {
            textMesh.alpha = Mathf.Lerp(startingValue, endingValue, count / duration);
            count += Time.deltaTime;
            yield return null;
        }
    }


    /// <summary>
    /// Fades the given AudioSource's volume in or out by a specified duration
    /// </summary>
    /// <param name="audio">The AudioSource to apply fading to</param>
    /// <param name="fadeMode">An enum with the options of IN and OUT</param>
    /// <param name="duration">Time in seconds</param>
    /// <returns></returns>
    public static IEnumerator Fade(AudioSource audio, FadeMode fadeMode, float duration)
    {
        float startingValue = 0;
        float endingValue = 0;
        if (FadeModeChecker(fadeMode, ref startingValue, ref endingValue) == false)
        {
            yield break;
        }

        float count = 0;
        while (count < duration)
        {
            audio.volume = Mathf.Lerp(startingValue, endingValue, count / duration);
            count += Time.deltaTime;
            yield return null;
        }
    }

    /// <summary>
    /// Fades the given AudioSource's volume in or out by a specified duration
    /// </summary>
    /// <param name="audio">The AudioSource to apply fading to</param>
    /// <param name="fadeMode">An enum with the options of IN and OUT</param>
    /// <param name="duration">Time in seconds</param>
    /// <returns></returns>
    public static IEnumerator Fade(AudioSource audio, FadeMode fadeMode, float duration, bool useUnscaled)
    {
        if (useUnscaled == false)
        {
            Debug.LogError("The boolean is unnecessary if its set to false, please call this method WITHOUT the boolean.");
            yield break;
        }
        float startingValue = 0;
        float endingValue = 0;
        if (FadeModeChecker(fadeMode, ref startingValue, ref endingValue) == false)
        {
            yield break;
        }

        float count = 0;
        while (count < duration)
        {
            audio.volume = Mathf.Lerp(startingValue, endingValue, count / duration);
            count += Time.unscaledDeltaTime;
            yield return null;
        }
    }

    /// <summary>
    /// Fades the given SpriteRenderer in or out by a specified duration
    /// </summary>
    /// <param name="sprite">The SpriteRenderer to apply fading to</param>
    /// <param name="fadeMode">An enum with the options of IN and OUT</param>
    /// <param name="duration">Time in seconds</param>
    /// <returns></returns>
    public static IEnumerator Fade(SpriteRenderer sprite, FadeMode fadeMode, float duration)
    {
        float startingValue = 0;
        float endingValue = 0;
        if(FadeModeChecker(fadeMode,ref startingValue, ref endingValue) == false)
        {
            yield break;
        }

        float count = 0;
        while (count < duration)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Lerp(startingValue, endingValue, count / duration));
            count += Time.deltaTime;
            yield return null;
        }
    }

    //If the given string is an invalid, return false
    private static bool FadeModeChecker(FadeMode fadeMode, ref float startingValue, ref float endingValue)
    {
        switch (fadeMode)
        { 
            case FadeMode.IN:
                startingValue = 0f;
                endingValue = 1f;
                return true;
            case FadeMode.OUT:
                startingValue = 1f;
                endingValue = 0f;
                return true;
            default:
                Debug.LogError("INVALID FADE MODE : " + fadeMode);
                return false;
        }
    }

    #endregion
}

public enum FadeMode
{
    IN,
    OUT
}
