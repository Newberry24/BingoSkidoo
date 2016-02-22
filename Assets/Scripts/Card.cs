using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card : MonoBehaviour {
    public Space[] spaces;
	void Start()
    {
        List<int> usedNumbers = new List<int>();
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 5; j++){
                int num;
                //do-while loop used to avoid repeating numbers.
                do{
                    num = spaces[i*5+j].GenerateNumber(i);
                } while (usedNumbers.Contains(num)) ;
                //add the number to the used numbers list
                usedNumbers.Add(num);
            }
        }
    }
}
