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
        //sameCellKeys보상 주고 파괴
        foreach (int[] a in sameCellKeys)
        {
            cells[a].CellDestruction();
        }
        //전체 세포들에게 자리 재배치 - 번호는 바로 배정받고 애니메이션은 이후에 한다.
        foreach (KeyValuePair<int[], Cell> a in cells)
        {
             a.Value.Relocation();
        }
    }

}
