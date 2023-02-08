using System;
using Game.Const;
using UnityEngine;

namespace _04.Game.Controller
{
    public class InputController : MonoBehaviour
    {
        private InputContext _inputContext;
        private float _time;
        private float _offsetX;
        private float _offsetY;
        private Vector3 _position;

        private void Start()
        {
            _inputContext = Contexts.sharedInstance.input;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Camera.main == null) return;
                var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
                if (hit.collider == null) return;
                _position = hit.transform.position;
                _inputContext.Replace_04GameComponentsClick((int)_position.x, (int)_position.y);

                _time = 0;
                _offsetX = 0;
                _offsetY = 0;
            }

            if (Input.GetMouseButton(0))
            {
                if (_time < 0.5f)
                {
                    _time += Time.deltaTime;
                    _offsetX += Input.GetAxis("Mouse X");
                    _offsetY += Input.GetAxis("Mouse Y");
                }
                else
                {
                    Slider();
                }
            }

            if (Input.GetMouseButtonUp(0) && _time is < 0.5f and > 0.1f)
            {
                Slider();
            }
        }

        private void Slider()
        {
            var direction = MathF.Abs(_offsetX) > Mathf.Abs(_offsetY)
                ? _offsetX > 0 ? SlideDirection.RIGHT : SlideDirection.LEFT
                : _offsetY > 0
                    ? SlideDirection.UP
                    : SlideDirection.DOWM;
            var pos = new CustomVector2((int)_position.x, (int)_position.y);
            _inputContext.Replace_04GameComponentsSlide(pos, direction);
        }
    }
}