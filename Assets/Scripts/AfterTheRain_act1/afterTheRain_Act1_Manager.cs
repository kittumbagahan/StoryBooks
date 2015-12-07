using UnityEngine;
using System.Collections;

public class afterTheRain_Act1_Manager : MonoBehaviour {

    public enum ETilDirection { left, right}
    public ETilDirection eTiltDir;
    public float maxTilt = 20;


	void Start () {
        WordGameManager.ins.delGenerateWord += TiltSlots;
	}


    void TiltSlots()
    {
        for (int i=0; i<InventoryManager.ins.slots.Count; i++)
        {
            RandomTilt(InventoryManager.ins.slots[i].transform);
        }
    }

    void RandomTilt(Transform t)
    {
        int rnd = Random.Range(0, 2);
        switch (rnd)
        {
            case 0:
                //eTiltDir = ETilDirection.left;
                t.SetLocalZRot(Random.Range(0,20f));
                break;
            case 1:
                //eTiltDir = ETilDirection.right; break;
                t.SetLocalZRot(Random.Range(340,360));
                break;
            default: break;
        }
    }
}
