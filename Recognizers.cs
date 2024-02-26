using COP4365_Project3.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace COP4365_Project3
{
    public abstract class Recognizer
    {
        public int patternSize { get; set; }
        public string patternName { get; set; }
        public Recognizer() { }
        public Recognizer(string name, int size) 
        {
            patternName = name;
            patternSize = size;
        }
        public override string ToString()   //Override for ToString so combobox displays the
        {                                   //pattern name instead of the recognizer type
            return patternName;
        }
        //Recognize method. goes through the list of stocks, and uses the patternsize to send sublists
        //to recognizePattern. returns an array of pairs, the starting index and patternsize
        public List<List<int>> recognize (List<SmartStock> Lss)
        {
            if (Lss == null) { return null; }
            List<List<int>> result = new List<List<int>>(Lss.Count);
            for (int i = patternSize-1; i < Lss.Count(); i++)
            {
                List<SmartStock> subList = Lss.GetRange(i - patternSize + 1, patternSize);
                if (RecognizePattern(subList))
                {
                    List<int> items = new List<int> { i - patternSize + 1, patternSize };
                    result.Add(items);  //add(i), changing to return array of start and patternsize
                }
            }
            return result;
        }
        //Basic method to be overidden
        protected virtual bool RecognizePattern(List<SmartStock> st) { return false; }
    }

    //The following are inherited classes of recognizer, each overriding the inherited RecognizePattern
    //method to enable their own reconizing pattern
    public class BullishRecognizer : Recognizer
    {
        public BullishRecognizer() : base("Bullish", 1) { }
        protected override bool RecognizePattern(List<SmartStock> st)
        {
            if (st[0].IsBullish)
                return true;
            return false;
        }
    }
    public class BearishRecognizer : Recognizer
    {
        public BearishRecognizer() : base("Bearish", 1) { }
        protected override bool RecognizePattern(List<SmartStock> st)
        {
            if (st[0].IsBearish)
                return true;
            return false;
        }
    }
    public class NeutralRecognizer : Recognizer
    {
        public NeutralRecognizer() : base("Neutral", 1) { }
        protected override bool RecognizePattern(List<SmartStock> st)
        {
            if (st[0].IsNeutral)
                return true;
            return false;
        }
    }
    public class MarubozuRecognizer : Recognizer
    {
        public MarubozuRecognizer() : base("Marubozu", 1) { }
        protected override bool RecognizePattern(List<SmartStock> st)
        {
            if (st[0].IsMarubozu)
                return true;
            return false;
        }
    }
    public class DojiRecognizer : Recognizer
    {
        public DojiRecognizer() : base("Doji", 1) { }
        protected override bool RecognizePattern(List<SmartStock> st)
        {
            if (st[0].IsDoji)
                return true;
            return false;
        }
    }
    public class DragonflyDojiRecognizer : Recognizer
    {
        public DragonflyDojiRecognizer() : base("DragonflyDoji", 1) { }
        protected override bool RecognizePattern(List<SmartStock> st)
        {
            if (st[0].IsDragonFlyDoji)
                return true;
            return false;
        }
    }
    public class GravestoneDojiRecognizer : Recognizer
    {
        public GravestoneDojiRecognizer() : base("GravestoneDoji", 1) { }
        protected override bool RecognizePattern(List<SmartStock> st)
        {
            if (st[0].IsGravestoneDoji)
                return true;
            return false;
        }
    }
    public class HammerRecognizer : Recognizer
    {
        public HammerRecognizer() : base("Hammer", 1) { }
        protected override bool RecognizePattern(List<SmartStock> st)
        {
            if (st[0].IsHammer)
                return true;
            return false;
        }
    }
    public class InvertedHammerRecognizer : Recognizer
    {
        public InvertedHammerRecognizer() : base("InvertedHammer", 1) { }
        protected override bool RecognizePattern(List<SmartStock> st)
        {
            if (st[0].IsInvertedHammer)
                return true;
            return false;
        }
    }
    public class BullishEngulfingRecognizer: Recognizer
    {
        public BullishEngulfingRecognizer() : base("BullishEngulfing", 2) { }
        protected override bool RecognizePattern(List<SmartStock> st)
        {
            if (st[0].IsBearish && st[1].IsBullish)
                if (st[0].TopPrice < st[1].TopPrice && st[0].BottomPrice > st[1].BottomPrice)
                    return true;
            return false;
        }
    }
    public class BearishEngulfingRecognizer : Recognizer
    {
        public BearishEngulfingRecognizer() : base("BearishEngulfing", 2) { }
        protected override bool RecognizePattern(List<SmartStock> st)
        {
            if (st[0].IsBullish && st[1].IsBearish)
                if (st[0].TopPrice < st[1].TopPrice && st[0].BottomPrice > st[1].BottomPrice)
                    return true;
            return false;
        }
    }
    public class EngulfingRecognizer : Recognizer
    {
        public EngulfingRecognizer() : base("Engulfing", 2) { }
        protected override bool RecognizePattern(List<SmartStock> st)
        {
            var bullish = new BullishEngulfingRecognizer();
            var bearish = new BearishEngulfingRecognizer();
            if (bullish.recognize(st).Count != 0 || bearish.recognize(st).Count != 0)
                return true;
            return false;
        }
    }
    public class BearishHaramiRecognizer : Recognizer
    {
        public BearishHaramiRecognizer() : base("BearishHarami", 2) { }
        protected override bool RecognizePattern(List<SmartStock> st)
        {
            if (st[0].IsBullish && st[1].IsBearish)
                if (st[0].TopPrice > st[1].TopPrice && st[0].BottomPrice < st[1].BottomPrice)
                    return true;
            return false;
        }
    }
    public class BullishHaramiRecognizer : Recognizer
    {
        public BullishHaramiRecognizer() : base("BullishHarami", 2) { }
        protected override bool RecognizePattern(List<SmartStock> st)
        {
            if (st[0].IsBearish && st[1].IsBullish)
                if (st[0].TopPrice > st[1].TopPrice && st[0].BottomPrice < st[1].BottomPrice)
                    return true;
            return false;
        }
    }
    public class PeakRecognizer : Recognizer
    {
        public PeakRecognizer() : base("Peak", 3) { }
        protected override bool RecognizePattern(List<SmartStock> st)
        {
            if (st[0].High < st[1].High && st[1].High > st[2].High)
                return true;
            return false;
        }
    }
    public class ValleyRecognizer : Recognizer
    {
        public ValleyRecognizer() : base("Valley", 3) { }
        protected override bool RecognizePattern(List<SmartStock> st)
        {
            if (st[0].Low > st[1].Low && st[1].Low < st[2].Low)
                return true;
            return false;
        }
    }
}