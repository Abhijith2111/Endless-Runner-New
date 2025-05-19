using System.Collections;
using UnityEngine;

public class TimeController : MonoBehaviour
{

   
        [Header("Visual Effects")]
        [SerializeField] private ParticleSystem slowMoParticles;
        [SerializeField] private AudioSource slowMoSound;

        private float originalTimeScale;
        private float originalFixedDeltaTime;
        private Coroutine currentSlowMoRoutine;

        private void Awake()
        {
            originalTimeScale = Time.timeScale;
            originalFixedDeltaTime = Time.fixedDeltaTime;
        }

        public void ActivateSlowMotion(float duration, float timeScale)
        {
            // Stop any existing slow-mo
            if (currentSlowMoRoutine != null)
                StopCoroutine(currentSlowMoRoutine);

            currentSlowMoRoutine = StartCoroutine(SlowMotionRoutine(duration, timeScale));
        }

        private IEnumerator SlowMotionRoutine(float duration, float targetTimeScale)
        {
            // Start slow-mo
            Time.timeScale = targetTimeScale;
            Time.fixedDeltaTime = originalFixedDeltaTime * targetTimeScale;

            // Visual/Sound effects
            if (slowMoParticles != null) slowMoParticles.Play();
            if (slowMoSound != null) slowMoSound.Play();

            // Wait for duration (using unscaled time)
            yield return new WaitForSecondsRealtime(duration);

            // End slow-mo
            ResetTimeScale();

            if (slowMoParticles != null) slowMoParticles.Stop();
        }

        private void ResetTimeScale()
        {
            Time.timeScale = originalTimeScale;
            Time.fixedDeltaTime = originalFixedDeltaTime;
        }

        private void OnDestroy()
        {
            // Ensure time resets if object is destroyed
            ResetTimeScale();
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }


