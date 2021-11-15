using System;
using System.Collections.Generic;
using System.Linq;

class Arge {
    
    public static int NbYear(int p0, double percent, int aug, int p) {
        int totalPeople = p0;
        int cycle = 0;
        while (totalPeople < p) {
          totalPeople = (int)(totalPeople + totalPeople * (percent/100) + aug);
          cycle+=1;
        }
        return cycle;
    }
}
public class Kata
{
    public static IEnumerable<string> OpenOrSenior(int[][] data)
    {
        string[] output = new string [data.Length];
        for (int index = 0; index < data.Length; index++)
        {
            output[index] = data[index][0] >= 55 && data[index][1] > 7 ? "Senior" : "Open";
        }
        return output;
    }
}