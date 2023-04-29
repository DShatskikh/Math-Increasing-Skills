using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Math
{
    public class AdminPanel : MonoBehaviour
    {
        [SerializeField]
        private List<TextMeshProUGUI> _textsRowLeft;
        
        [SerializeField]
        private List<TextMeshProUGUI> _textsRowRight;

        [SerializeField]
        private List<GameObject> _examlpes;

        [SerializeField]
        private GameObject _canvas;
        
        private int _currentText = 0;
        private int _currentRow = 0;

        private IEnumerator Start()
        {
            print("Worked");
            UpdateTextChoose();
            
            while (true)
            {
                yield return new WaitUntil(() => SwitchText());
                yield return new WaitUntil(() => Input.GetButtonUp("Vertical") || Input.GetButtonUp("Horizontal"));
            }
        }
        
        private void Update()
        {
            if (Input.GetButtonDown("Cancel"))
            {
                Open();
            }
        }

        private bool SwitchText()
        {
            if (!_canvas.activeSelf)
                return false; 
            
            var vertical = (int)Input.GetAxisRaw("Vertical");
            var horizontal = (int)Input.GetAxisRaw("Horizontal");
            
            if (vertical != 0)
            {
                print("Vertical");
                _currentText -= vertical;
                UpdateTextChoose();
                return true;
            }

            if (horizontal != 0)
            {
                print("Horizontal");
                _currentRow += horizontal;
                UpdateTextChoose();
                return true;
            }

            if (Input.GetButtonDown("Submit"))
            {
                print("Submit");
                var numberExamples = _currentText * 2 + _currentRow;

                for (int i = 0; i < _examlpes.Count; i++)
                {
                    _examlpes[i].SetActive(i == numberExamples);
                }
                
                Close();
            }

            return false;
        }

        private void UpdateTextChoose()
        {
            _currentRow = Mathf.Clamp(_currentRow, 0, 1);
            
            var currentTexts = _currentRow == 0 ? _textsRowLeft : _textsRowRight;
            
            _currentText = Mathf.Clamp(_currentText, 0, currentTexts.Count - 1);
            
            var previousTexts = _currentRow != 0 ? _textsRowLeft : _textsRowRight;

            for (int i = 0; i < previousTexts.Count; i++)
            {
                previousTexts[i].color = Color.white;
            }
            
            for (int i = 0; i < currentTexts.Count; i++)
            {
                currentTexts[i].color = i == _currentText ? Color.yellow : Color.white;
            }
        }

        private void Open()
        {
            if (_canvas.activeSelf)
                return;
            
            for (int i = 0; i < _examlpes.Count; i++)
            {
                _examlpes[i].SetActive(false);
            }
            
            _canvas.SetActive(true);
        }

        private void Close()
        {
            if (!_canvas.activeSelf)
                return;
            
            _canvas.SetActive(false);
        }
    }
}