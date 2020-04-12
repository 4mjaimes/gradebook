using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Total / Count;
            }
        }
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var letter when letter >= 90.0:
                        return 'A';
                    case var letter when letter >= 80.0:
                        return 'B';
                    case var letter when letter >= 70.0:
                        return 'C';
                    case var letter when letter >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }
        public double High;
        public double Low;
        public double Total;
        public int Count;

        public Statistics()
        {
            Total = 0.0;
            Count = 0;
            Low = double.MaxValue;
            High = double.MinValue;
        }
        public void Add(double number)
        {
            Total += number;
            Count++;
            Low = Math.Min(Low, number);
            High = Math.Max(High, number);
        }
    }
}