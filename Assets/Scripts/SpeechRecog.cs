using Microsoft.MixedReality.Toolkit.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public struct PhraseAction
{
    [SerializeField]
    private string phrase;

    [SerializeField]
    private UnityEvent action;

    public string Phrase => phrase;

    public UnityEvent Action => action;
}

public class SpeechRecog : MonoBehaviour
{
    [SerializeField]
    private List<PhraseAction> phraseActions;
    private float sliderVar;
    // Start is called before the first frame update
    void Start()
    {
        var phraseRecognitionSubsystem = SpeechUtils.GetSubsystem();
        foreach (var phraseAction in phraseActions)
        {
            if (!string.IsNullOrEmpty(phraseAction.Phrase) &&
          phraseAction.Action.GetPersistentEventCount() > 0)
            {
                phraseRecognitionSubsystem.
                  CreateOrGetEventForPhrase(phraseAction.Phrase).
                    AddListener(() => phraseAction.Action.Invoke());
            }
        }
    }
}
