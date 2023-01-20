using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{

    public void setSkybox(Material newSky)
    {
        RenderSettings.skybox = newSky;
    }

    public void setAmbientIntensity(float intensity)
    {
        RenderSettings.ambientIntensity = intensity;
    }

    public void setFog(bool fogEnabled)
    {
        RenderSettings.fog = fogEnabled;
    }

    public void fogColor(string fogCol)
    {
        Color newCol = Color.clear; ColorUtility.TryParseHtmlString(fogCol, out newCol);
        RenderSettings.fogColor = newCol;
    }

    public void setAmbientLight(string col)
    {
        Color newCol = Color.clear; ColorUtility.TryParseHtmlString(col, out newCol);
        RenderSettings.fogColor = newCol;
    }

    public void setReflectionIntensity(float intensity)
    {
        RenderSettings.reflectionIntensity = intensity;
    }

}
