using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Math
{
    public class Clamp : MonoBehaviour
    {
        public float MaxHealth;
        public float Health;

        public TextMeshProUGUI Text;
        public Scrollbar Scrollbar;
        public Heart Heart;

        private void OnEnable()
        {
            Heart.OnTakeDamage += TakeDamage;
            Heart.OnTreatment += Treatment;
        }

        private void OnDisable()
        {
            Heart.OnTakeDamage -= TakeDamage;
            Heart.OnTreatment -= Treatment;
        }

        private void Start()
        {
            UpdateText();
            UpdateBar();
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;
            ClampHeath();
            print("TakeDamage Health: " + Health);
            UpdateText();
            UpdateBar();
        }

        public void Treatment(float value)
        {
            Health += value;
            ClampHeath();
            print("Treatment Health: " + Health);
            UpdateText();
            UpdateBar();
        }

        private void UpdateText()
        {
            Text.text = $"{Health}/{MaxHealth}";
        }

        private void UpdateBar()
        {
            Scrollbar.size = Health/MaxHealth;
        }
        
        private void ClampHeath()
        {
            Health = Mathf.Clamp(Health, 0, MaxHealth);
        }
    }
}