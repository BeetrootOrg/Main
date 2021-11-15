using System;

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