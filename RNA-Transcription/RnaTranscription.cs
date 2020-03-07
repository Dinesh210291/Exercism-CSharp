using System;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        if (!string.IsNullOrEmpty(nucleotide))
        {
            nucleotide = nucleotide.ToUpper();

            char[] dnaArray = nucleotide.ToCharArray();
            char[] rnaArray = new char[dnaArray.Length];

            for (int i = 0; i < dnaArray.Length; i++)
            {
                switch (dnaArray[i])
                {
                    case 'G':
                        rnaArray[i] = 'C';
                        break;
                    case 'C':
                        rnaArray[i] = 'G';
                        break;
                    case 'T':
                        rnaArray[i] = 'A';
                        break;
                    case 'A':
                        rnaArray[i] = 'U';
                        break;
                    default:
                        break;
                }
            }
            return string.IsNullOrEmpty(new string(rnaArray)) ? nucleotide : new string(rnaArray);
        }
        return nucleotide;
    }
}