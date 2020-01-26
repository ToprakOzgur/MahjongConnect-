using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FaceController : MonoBehaviour
{
    [SerializeField] private Sprite[] faces;

    public Face[] GetShuffledFaces(int spriteCount)
    {
        var spritesIndex = new List<int>();

        Debug.Log(spriteCount + " different sprites needed");

        for (int i = 0; i < faces.Length; i++)
        {
            spritesIndex.Add(i);
        }

        //Shullfle an all sprites index
        var shuffleAllFaces = RandomNumberGenerator.ShuffleList(spritesIndex);

        //select first sprites from shuffled list 
        var selectFromShuffledFaces = shuffleAllFaces.Take(spriteCount);

        //doubles all selected sprites so makes pairs
        var pairs = selectFromShuffledFaces.Concat(selectFromShuffledFaces).ToList();

        //shuffle pairs
        var shuffledPairs = RandomNumberGenerator.ShuffleList(pairs);


        var resultArray = new Face[spriteCount * 2];

        for (int i = 0; i < spriteCount * 2; i++)
        {
            var face = new Face();
            face.sprite = faces[shuffledPairs[i]];
            face.number = shuffledPairs[i];
            resultArray[i] = face;
        }

        return resultArray;
    }


}
