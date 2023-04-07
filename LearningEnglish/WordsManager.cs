using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningEnglish
{
    class WordsManager
    {
        private string[] words;
        private string pathWords;
        private Random rng;
        private int indexNow = -1; // index for go to next or go to previous
        private int length = 0;

        public WordsManager() {
            pathWords = Path.Combine(Directory.GetCurrentDirectory(), "words.txt");
            words = File.ReadAllLines(pathWords);
            rng = new Random();
            length= words.Length;

            //Shuffle the array
            _ShuffleWords();
        }

        private void _ShuffleWords()
        {
            int n = words.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                string temp = words[n];
                words[n] = words[k];
                words[k] = temp;
            }
        }

        public string Next()
        {

            if(indexNow >= length - 1)
            {
                indexNow = -1; // when return ++ => index = 0
                _ShuffleWords();
            }

            return words[++indexNow];
        }

        public string Previous()
        {
            if (indexNow <= 0)
            {
                indexNow = length; // => index = length - 1
            }

            return words[--indexNow];
        }
    }
}
