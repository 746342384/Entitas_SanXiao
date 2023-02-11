using _04.Game.Views;
using Entitas;
using Entitas.Unity;
using Game.Const;
using UnityEngine;

namespace Game.Views
{
    public class AudioView : MonoBehaviour, IGameComponentsAudioListener, IView
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Link(IEntity entity, IContext context)
        {
            if (entity is GameEntity gameEntity)
            {
                gameEntity.AddGameComponentsAudioListener(this);
            }
        }

        public void OnGameComponentsAudio(GameEntity entity, string path)
        {
            if (_audioSource == null)
            {
                _audioSource = gameObject.AddComponent<AudioSource>();
            }

            _audioSource.clip = Resources.Load<AudioClip>(ResPath.AudioPath + path);
            _audioSource.Play();
        }
    }
}