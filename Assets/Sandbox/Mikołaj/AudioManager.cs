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
        }
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
    [SerializeField] float rate; //Czêstotliwoœæ grania dŸwiêku
    [SerializeField] GameObject player; //Obiekt pe³ni¹cy rolê gracza
    [SerializeField] Movement controller; //kod odpowiadaj¹cy za poruszanie siê gracza
    [SerializeField] float FootstepRate;
    float time;

    public void PlayMusic()
    {
        RuntimeManager.PlayOneShot(MusicEvent);
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
