using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmAudioSource;

    private Coroutine _coroutine;
    private float _targetVolume;

    private void OnTriggerEnter()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _targetVolume = 1;
        _coroutine = StartCoroutine(ChangeVolumeSmoothly());
    }

    private void OnTriggerExit()
    {      
        StopCoroutine(_coroutine);

        _targetVolume = 0;
        _coroutine = StartCoroutine(ChangeVolumeSmoothly());
    }

    private IEnumerator ChangeVolumeSmoothly()
    {
        float speed = 0.5f;

        while(_alarmAudioSource.volume != _targetVolume)
        {
            _alarmAudioSource.volume = Mathf.MoveTowards(_alarmAudioSource.volume, _targetVolume, speed * Time.deltaTime);

            yield return null;
        }
    }
}