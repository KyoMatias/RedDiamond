using UnityEngine;

public enum ShapeType
{
    Box
}

public class Shape : MonoBehaviour
{
    [field: SerializeField] public bool IsInteractable { get; private set; }

    public ShapeType ShapeType { get; set; }

    public virtual void DrawCollider() { }

    public virtual void DrawLine(Vector3[] vectorArray) { }
}
