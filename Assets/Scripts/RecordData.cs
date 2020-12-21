using System;
using System.Collections.Generic;

[System.Serializable]
public class RecordData: IComparable<RecordData>, IEquatable<RecordData>
{
    public int minute;
    public int secund;

    public RecordData(float minute,float secund)
    {
        this.minute = (int)System.Math.Floor(minute);
        this.secund = (int)System.Math.Floor(secund);
    }
    public RecordData()
    {
        this.minute = 10;
        this.secund = 0;
    }

    public int CompareTo(RecordData other)
    {
        if (minute > other.minute)
        {
            return 1;
        }
        else if (minute < other.minute)
        {
            return -1;
        }
        else
        {
            if (secund > other.secund)
            {
                return 1;
            }
            else if (secund < other.secund)
            {
                return -1;
            }
            else 
            {
                return 0;
            }
        }

    }

    public bool Equals(RecordData other)
    {
        return minute == other.minute && secund == other.secund;
    }
}