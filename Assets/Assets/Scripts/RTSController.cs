using System.Collections.Generic;
using UnityEngine;

public class RTSController : MonoBehaviour
{
    [Header("Layer")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask unitLayer;

    private List<Unit> selectedUnits = new();

    private void Update()
    {
        HandleSelection();
        HandleMovement();
    }

    private void HandleSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, unitLayer))
            {
                Unit unit = hit.collider.GetComponent<Unit>();

                if (unit != null)
                {
                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        ClearSelection();
                    }

                    SelectUnit(unit);
                }
            }
            else
            {
                ClearSelection();
            }
        }
    }

    private void HandleMovement()
    {
        if (Input.GetMouseButtonDown(1) && selectedUnits.Count > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundLayer))
            {
                foreach (Unit unit in selectedUnits)
                {
                    unit.MoveTo(hit.point);
                }
            }
        }
    }

    private void SelectUnit(Unit unit)
    {
        if(!selectedUnits.Contains(unit))
        {
            selectedUnits.Add(unit);
            unit.Select();
        }
    }

    private void ClearSelection()
    {
        foreach(Unit unit in selectedUnits)
        {
            unit.Deselect();
        }

        selectedUnits.Clear();
    }
}
