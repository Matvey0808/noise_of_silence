using UnityEngine;
using UnityEngine.InputSystem;

public class MenuAnimation : MonoBehaviour
{
     private bool isPlaying = false;
    private float animationProgress = 0f;
    private Vector3 startPosition;
    private Quaternion startRotation;
    
    [Header("Настройки анимации")]
    public float duration = 1f; // Длительность анимации в секундах
    public Vector3 moveOffset = new Vector3(0, 2, 0); // На сколько переместится
    public Vector3 rotationAmount = new Vector3(0, 360, 0); // На сколько повернется
    
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }
    
    void Update()
    {
        // Запускаем анимацию по нажатию
        if (Keyboard.current.enterKey.wasPressedThisFrame && !isPlaying)
        {
            StartAnimation();
        }
        
        // Если анимация играет - обновляем
        if (isPlaying)
        {
            UpdateAnimation();
        }
    }
    
    void StartAnimation()
    {
        isPlaying = true;
        animationProgress = 0f;
        Debug.Log("Анимация началась!");
    }
    
    void UpdateAnimation()
    {
        // Увеличиваем прогресс анимации
        animationProgress += Time.deltaTime / duration;
        
        // Ограничиваем прогресс от 0 до 1
        float t = Mathf.Clamp01(animationProgress);
        
        // Плавная кривая (ease-in-out)
        float smoothedT = Mathf.SmoothStep(0f, 1f, t);
        
        // Применяем анимацию перемещения
        transform.position = startPosition + moveOffset * smoothedT;
        
        // Применяем анимацию вращения
        transform.rotation = startRotation * Quaternion.Euler(rotationAmount * smoothedT);
        
        // Если анимация закончилась
        if (t >= 1f)
        {
            EndAnimation();
        }
    }
    
    void EndAnimation()
    {
        isPlaying = false;
        // Опционально: возвращаем в исходное состояние
        // transform.position = startPosition;
        // transform.rotation = startRotation;
        Debug.Log("Анимация завершена!");
    }
}
