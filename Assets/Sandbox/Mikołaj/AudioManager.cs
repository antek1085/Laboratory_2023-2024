using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Audio
{
    public static AudioManager manager;
    public static void Play(string what)
    {
        switch (what)
        {
            case "PickUpEvent":
                manager.PlayPickUp();
                break;
            case "PlaceDownEvent":
                manager.PlayPlaceDown();
                break;
            case "LabstationEvent":
                manager.PlayLabstation();
                break;
            case "MortarEvent":
                manager.PlayMortar();
                break;
            case "PillcutterEvent":
                manager.PlayPillcutter();
                break;
            case "SucessEvent":
                manager.PlaySucess();
                break;
            case "FailEvent":
                manager.PlayFail();
                break;
            case "PlantHarvestEvent":
                manager.PlayPlantHarvest();
                break;
            case "ClickUIEvent":
                manager.PlayClickUI();
                break;
            case "PillsPickUpEvent":
                manager.PlayPillsPickUp();
                break;
            case "SyropPickUpEvent":
                manager.PlaySyropPickUp();
                break;
            case "BalsamPickUpEvent":
                manager.PlayBalsamPickUp();
                break;
            case "BellRingEvent":
                manager.PlayBellRing();
                break;
            case "TrashbinEvent":
                manager.PlayTrashbin();
                break;
        }
    }
    public static void PauseMusic() 
    {
        if (manager) manager.PauseMusic(true);
    }

    public static void ResumeMusic()
    {
        if (manager) manager.PauseMusic(false);
    }
}
public class AudioManager : MonoBehaviour //Kod przypisuje siê do pustego obiektu na scenie
{
    [SerializeField] EventReference FootstepEvent;
    [SerializeField] EventReference MusicEvent;
    [SerializeField] EventReference PickUpEvent;
    [SerializeField] EventReference PlaceDownEvent;
    [SerializeField] EventReference LabstationEvent;
    [SerializeField] EventReference MortarEvent;
    [SerializeField] EventReference PillcutterEvent;
    [SerializeField] EventReference SucessEvent;
    [SerializeField] EventReference FailEvent;
    [SerializeField] EventReference PlantHarvestEvent;
    [SerializeField] EventReference ClickUIEvent;
    [SerializeField] EventReference PillsPickUpEvent;
    [SerializeField] EventReference SyropPickUpEvent;
    [SerializeField] EventReference BalsamPickUpEvent;
    [SerializeField] EventReference BellRingEvent;
    [SerializeField] EventReference TrashbinEvent;
    [SerializeField] float rate; //Czêstotliwoœæ grania dŸwiêku
    [SerializeField] GameObject player; //Obiekt pe³ni¹cy rolê gracza
    [SerializeField] Movement controller; //kod odpowiadaj¹cy za poruszanie siê gracza
    [SerializeField] float FootstepRate;
    float time;
    FMOD.Studio.EventInstance backgroundMusic;

    public void PlayMusic()
    {
        backgroundMusic = FMODUnity.RuntimeManager.CreateInstance(MusicEvent);
        backgroundMusic.start();
    }

    public void PauseMusic(bool pause)
    {
        backgroundMusic.setPaused(pause);
    }

    public void OnDestroy()
    {
        backgroundMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    public void PlayPickUp()
    {
        RuntimeManager.PlayOneShot(PickUpEvent);
    }

    public void PlayPlaceDown()
    {
        RuntimeManager.PlayOneShot(PlaceDownEvent);
    }

    public void PlayLabstation()
    {
        RuntimeManager.PlayOneShot(LabstationEvent);
    }

    public void PlayMortar()
    {
        RuntimeManager.PlayOneShot(MortarEvent);
    }

    public void PlayPillcutter()
    {
        RuntimeManager.PlayOneShot(PillcutterEvent);
    }

    public void PlayFootstep()
    {
        RuntimeManager.PlayOneShotAttached(FootstepEvent, player);
    }

    public void PlaySucess()
    {
        RuntimeManager.PlayOneShotAttached(SucessEvent, player);
    }

    public void PlayFail()
    {
        RuntimeManager.PlayOneShotAttached(FailEvent, player);
    }

    public void PlayPlantHarvest()
    {
        RuntimeManager.PlayOneShot(PlantHarvestEvent);
    }

    public void PlayClickUI()
    {
        RuntimeManager.PlayOneShotAttached(ClickUIEvent, player);
    }

    public void PlayPillsPickUp()
    {
        RuntimeManager.PlayOneShotAttached(PillsPickUpEvent, player);
    }

    public void PlaySyropPickUp()
    {
        RuntimeManager.PlayOneShotAttached(SyropPickUpEvent, player);
    }

    public void PlayBalsamPickUp()
    {
        RuntimeManager.PlayOneShotAttached(BalsamPickUpEvent, player);
    }

    public void PlayBellRing()
    {
        RuntimeManager.PlayOneShotAttached(BellRingEvent, player);
    }

    public void PlayTrashbin()
    {
        RuntimeManager.PlayOneShotAttached(TrashbinEvent, player);
    }

    private void Start()
    {
        PlayMusic();
        Audio.manager = this;
    }
    
    void FixedUpdate()
    {
        time += Time.deltaTime;
        float speed = controller.CurrentSpeed / FootstepRate;

        if(speed > 0f) //dzia³a, nie tykaæ
        {
            if(time >= (rate/speed))
            {
                PlayFootstep();
                time = 0;
            }
        }
    }
}
