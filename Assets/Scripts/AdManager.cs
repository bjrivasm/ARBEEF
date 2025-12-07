using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsInitializationListener
{
    public static AdManager instance;
    [SerializeField] private string android_ID;
    [SerializeField] private string iOS_ID;
    [SerializeField] private bool testMode;
    private string placementID = "Interstitial_";

    private Action _onAdClosed;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
#if UNITY_ANDROID || UNITY_EDITOR || UNITY_STANDALONE_WIN
        Advertisement.Initialize(android_ID, testMode, this);
        placementID += "Android";
#elif UNITY_IOS
		Advertisement.Initialize(iOS_ID, testMode, this);
		placementID += "iOS";
#endif
    }

    // Método para usar en otros scripts cuando queremos mostrar un anuncio
    public void ShowAd(System.Action onAdClosed = null)
    {
        _onAdClosed = onAdClosed;
        Advertisement.Load(placementID, this);
    }

    // Implementación de la interfaz de IUnityAdsLoadListener
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show(placementID, this);
    }
    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("El anuncio no se ha podido cargar");
        _onAdClosed?.Invoke();
    }

    // Implementación de la interfaz de IUnityAdsShowListener
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("El anuncio ha fallado al mostrarse");
        _onAdClosed?.Invoke();
    }
    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("El anuncio ha comenzado");
    }
    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("El anuncio se muestra al clickar");
    }
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("El anuncio se ha completado");
        _onAdClosed?.Invoke();
        _onAdClosed = null;
    }

    // Implementación de la interfaz de IUnityAdsInitializationListener
    public void OnInitializationComplete()
    {
        Debug.Log("El sistema de anuncios se ha iniciado");
    }
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("El sistema de anuncios no se ha podido iniciar");
    }
}