using System.Collections;
using UnityEngine;

/// <summary>
/// A collection of graphical effects.
/// </summary>
public class Effects : MonoBehaviour
{
    // 0 - 1 in
    //1 - 0 out
    #region Fade Function Variables
    //This function uses non changing strings
    //Static readonly strings, stops unnecessary memory allocation
    private static readonly string _in = "in";
    private static readonly string _out = "out";
    #endregion
    #region Fade Function Overloads

    /// <summary>
    /// Fades the given CanvasGroup in or out by a specified duration.
    /// </summary>
    /// <param name="canvasGroup">The canvasGroup to apply fading to</param>
    /// <param name="fadeMode">A String value that must either be "in" or "out". Determines whether to fade in or out the given object</param>
    /// <param name="duration">Time in seconds</param>
    /// <returns></returns>
    public static IEnumerator Fade(CanvasGroup canvasGroup, string fadeMode, float duration)
    {
        float startingValue = 0;
        float endingValue = 0;
        if (FadeModeChecker(fadeMode,ref startingValue,ref endingValue) == false)
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

    /// <summary>
    /// Fades the given AudioSource's volume in or out by a specified duration
    /// </summary>
    /// <param name="audio">The AudioSource to apply fading to</param>
    /// <param name="fadeMode">A String value that must either be "in" or "out". Determines whether to fade in or out the given object</param>
    /// <param name="duration">Time in seconds</param>
    /// <returns></returns>
    public static IEnumerator Fade(AudioSource audio, string fadeMode, float duration)
    {
        float startingValue = 0;
        float endingValue = 0;
        if (FadeModeChecker(fadeMode,ref startingValue,ref endingValue) == false)
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
    /// Fades the given SpriteRenderer in or out by a specified duration
    /// </summary>
    /// <param name="sprite">The SpriteRenderer to apply fading to</param>
    /// <param name="fadeMode">A String value that must either be "in" or "out". Determines whether to fade in or out the given object</param>
    /// <param name="duration">Time in seconds</param>
    /// <returns></returns>
    public static IEnumerator Fade(SpriteRenderer sprite, string fadeMode, float duration)
    {
        float startingValue = 0;
        float endingValue = 0;
        if(FadeModeChecker(fadeMode,ref startingValue,ref endingValue) == false)
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
    private static bool FadeModeChecker(string fadeMode, ref float startingValue, ref float endingValue)
    {
        if (fadeMode.Equals(_in))
        {
            startingValue = 0f;
            endingValue = 1f;
            return true;
        }
        else if (fadeMode.Equals(_out))
        {
            startingValue = 1f;
            endingValue = 0f;
            return true;
        }
        else
        {
            Debug.LogError("INVALID FADE MODE : " + fadeMode);
            return false;
        }
    }

    #endregion
}
