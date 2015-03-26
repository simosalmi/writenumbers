using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumbersApi.Models
{
    public class DigitGroup
    {
        #region Properties and Fields

        public BasicNumberWriter Writer;

        private string _WrittenNumber;
        public string WrittenNumber
        {
            get
            {
                if (string.IsNullOrEmpty(_WrittenNumber))
                {
                    return "";
                }
                else
                {
                    return _WrittenNumber.Trim();
                }
            }
        }
        
        public string WrittenNumberSeparator { get; set; }
        
        public int IntValue
        {
            get
            {
                int intvalue;
                Int32.TryParse(UnprocessedValue, out intvalue);
                return intvalue;
            }
        }

        public List<int> Digits
        {
            get
            {
                List<int> result = new List<int>();
                foreach (char c in UnprocessedValue)
                {
                    int intvalue;
                    Int32.TryParse(c.ToString(), out intvalue);
                    result.Add(intvalue);
                }
                return result;
            }
        }

        public string UnprocessedValue { get; set; }
        
        public int Scale { get; set; }

        #endregion Properties and Fields

        public DigitGroup AppendWrittenNumber(string value, bool separateWord = true)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (string.IsNullOrWhiteSpace(WrittenNumber))
                {
                    _WrittenNumber = value;
                }
                else
                {
                    if (separateWord && !WrittenNumber.EndsWith(WrittenNumberSeparator))
                    {
                        _WrittenNumber += WrittenNumberSeparator;
                    }
                    _WrittenNumber += value;
                }
            }
            return this;
        }

        public DigitGroup AddHundredsWords()
        {
            Writer.AddHundredsWordsToGroup(this);
            return this;
        }

        public DigitGroup AddTensWords()
        {
            Writer.AddTensWordsToGroup(this);
            return this;
        }

        public DigitGroup AppendScale()
        {
            Writer.AppendScaleToGroup(this);
            return this;
        }
    }
}