using NumbersApi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Web;


namespace NumbersApi.Models
{
    public class EnGbNumberWriter : BasicNumberWriter, INumberWriter
    {
        public new CultureInfo Culture
        {
            get
            {
                return CultureInfo.GetCultureInfo("en-gb");
            }
        }

        public override BasicNumberWriter Write(INumberWriterOptions options)
        {
            base.Write(options);                                              

            WriteSmallNumber();

            if (WrittenNumber == null)
            {
                SplitInGroups(AbsNumber);
                ProcessAndRecombineGroups().PostProcessWrittenNumber();                
            }

            return this;            
        }

        protected BasicNumberWriter WriteSmallNumber()
        {            
            if (AbsNumber <= 12)
            {
                if(AbsNumber < 10)
                {
                    WrittenNumber = base.WriteDigit(NumberString);
                }
                else
                {
                    WrittenNumber += ResourceManager.GetString("number" + NumberString, Culture);
                }
            }
            
            return this;
        }

        public override BasicNumberWriter PostProcessWrittenNumber()
        {
            base.PostProcessWrittenNumber();

            //refers to test:
            //when_the_final_group_does_not_include_any_hundreds_
            //and_there_is_more_than_one_non_blank_group_
            //the_final_comma_is_replaced_with_and
            int hundredDigitOfFinalGroup = Groups[0].Digits[0];
            bool moreThanOneNonBlankGroup = Groups.Count(g => g.UnprocessedValue != "000") > 1;

            string comma = ResourceManager.GetString("groupConjunction", Culture);
            string textToInsert = ResourceManager.GetString("writtenNumberSeparator", Culture) 
                + ResourceManager.GetString("conjunction", Culture);

            if (hundredDigitOfFinalGroup == 0 && moreThanOneNonBlankGroup)
            {
                int lastIndexOfComma = WrittenNumber.LastIndexOf(comma);
                if(lastIndexOfComma != -1)
                {
                    //replace it with " and"
                    StringBuilder stringEditHelper = new StringBuilder(WrittenNumber);
                    stringEditHelper.Remove(lastIndexOfComma, comma.Length);
                    stringEditHelper.Insert(lastIndexOfComma, textToInsert);
                    WrittenNumber = stringEditHelper.ToString();
                }
            }

            return this;
        }

        public override DigitGroup AddTensWordsToGroup(DigitGroup group)
        {
            base.AddTensWordsToGroup(group);

            string tens = group.UnprocessedValue[1].ToString();
            string units = group.UnprocessedValue[2].ToString();            

            if(tens == "1")
            {
                int intUnits = Int32.Parse(units);
                if(intUnits >= 0 && intUnits <= 2)
                {
                    //ten, eleven, twelve
                    group.AppendWrittenNumber(ResourceManager.GetString("number" + tens + units, Culture));
                }
                else
                {
                    //fourteen "special case"
                    if(intUnits == 4)
                    {
                        group.AppendWrittenNumber(ResourceManager.GetString("number" + units, Culture));
                    }
                    else
                    {
                        //thirteen, fifteen, etc.
                        group.AppendWrittenNumber(ResourceManager.GetString("number" + units + "x", Culture));                    
                    }
                    //adding teen
                    group.AppendWrittenNumber(value: ResourceManager.GetString("teenPart", Culture), separateWord: false);
                }
            }
            else
            {
                if (Int32.Parse(tens) >= 2)
                {
                    // thirty, forty etc.
                    group.AppendWrittenNumber(ResourceManager.GetString("number" + tens + "x", Culture))
                        .AppendWrittenNumber(value: ResourceManager.GetString("tenSuffix", Culture), separateWord: false);
                }
                if (units != "0")
                {
                    group.AppendWrittenNumber(WriteDigit(units));
                }
            }
            
            return group;
        }

        public override BasicNumberWriter AddHundredsWordsToGroup(DigitGroup group)
        {
            base.AddHundredsWordsToGroup(group);

            string hundredsDigit = group.UnprocessedValue[0].ToString();

            if (Int32.Parse(hundredsDigit) != 0)
            {
                group.AppendWrittenNumber(this.WriteDigit(hundredsDigit));

                group.AppendWrittenNumber(ResourceManager.GetString("hundred", Culture));

                if (group.IntValue % 100 != 0)
                {
                    group.AppendWrittenNumber(ResourceManager.GetString("conjunction", Culture));
                }
            }

            return this;
        }

        public override DigitGroup ProcessGroup(DigitGroup group)
        {
            return base.ProcessGroup(group)
                .AddHundredsWords()
                .AddTensWords()
                .AppendScale();
        }

    }
}