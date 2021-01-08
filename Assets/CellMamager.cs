using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellMamager : MonoBehaviour
{
    [HideInInspector] public Dictionary<int[], Cell> cells;
    //[HideInInspector] public List<int> cells;
    //[HideInInspector] public Dictionary<int, List<int>> columnCells;
    public Transform cellParent;
    public static CellMamager instansce;
    // Start is called before the first frame update
    void Start()
    {
        instansce = this;
        cells = new Dictionary<int[], Cell>();
        for(int i = 0; i < cellParent.childCount; ++i)
        {
            Cell cell = cellParent.GetChild(i).GetComponent<Cell>();
            cells.Add(new int[] { cell.row, cell.column }, cell);
            //cells[cell.row] = 
        }
    }
    void CheckCell()
    {
        foreach(KeyValuePair<int[], Cell> a in cells)
        {
            List<int[]> sameCellKeys = a.Value.GetSameCell();
            CallCellDestruction(sameCellKeys);
        }
        
    }
    void CallCellDestruction(List<int[]> sameCellKeys)
    {
        //sameCellKeys���� �ְ� �ı�
        foreach (int[] a in sameCellKeys)
        {
            cells[a].CellDestruction();
        }
        //��ü �����鿡�� �ڸ� ���ġ - ��ȣ�� �ٷ� �����ް� �ִϸ��̼��� ���Ŀ� �Ѵ�.
        foreach (KeyValuePair<int[], Cell> a in cells)
        {
             a.Value.Relocation();
        }
    }

}
