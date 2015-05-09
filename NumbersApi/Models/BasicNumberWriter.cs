using NumbersApi.Models.Exceptions;
using NumbersApi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;

namespace NumbersApi.Models
{
    public abstract class BasicNumberWriter : INumberWriter
    {
        protected int AbsNumber;
        protected string NumberString;
        protected bool WriteFinished = false;
        protected bool NegativeNumber = false;
        protected ResourceManager ResourceManager = Resources.Numbers.ResourceManager;
        
        public System.Globalization.CultureInfo Culture
        {
            get { return CultureInfo.GetCultureInfo(ResourceManager.GetString("DefaultCulture")); }
        }               
        
        public string WrittenNumber { get; set; }

        #region Error
        private string _Error;

        public string Error {
            get
            {
                return _Error;
            }
        }

        protected void AppendError(string error)
        {
            if (!string.IsNullOrWhiteSpace(Error))
            {
                _Error += " ";
            }
            _Error += error;
        }
        #endregion Error

        #region Groups
        public List<DigitGroup> Groups { get; set; }

        public virtual BasicNumberWriter Write(INumberWriterOptions options)
        {            
            List<string> enabledLanguages = Utilities.SplitToList(Resources.Numbers.EnabledLanguagesArray, Resources.Numbers.SettingsArraySeparator);
            bool supportedCulture = enabledLanguages.Any(el => el == options.CultureName.ToLower());

            if (false == supportedCulture)
            {
                string unsupportedCultureMessage = Resources.Numbers.UnsupportedCultureMessage;
                if(false == options.AllowCultureFallback)
                {
                    throw new UnsupportedCultureException(unsupportedCultureMessage);
                }
                else
                {
                    //go on but give error message to the caller
                    this.AppendError(unsupportedCultureMessage);
                }
            }

            int parsedValue = 0;
            try
            {
                parsedValue = Int32.Parse(options.Value);
            }
            catch(OverflowException ex)
            {
                throw new OverflowException(ResourceManager.GetString("NumberOverflowErrorMessage", Culture).Replace("@", MinValue.ToString()).Replace("#", MaxValue.ToString()), ex);    
            }
            catch(FormatException ex)
            {
                throw new FormatException(ResourceManager.GetString("InvalidNumberErrorMessage", Culture), ex);
            }
            catch(ArgumentNullException ex)
            {
                throw new ArgumentNullException(ResourceManager.GetString("ArgumentNullErrorMessage", Culture), ex);
            }


            NegativeNumber = parsedValue < 0;

            AbsNumber = Math.Abs(parsedValue);
            NumberString = AbsNumber.ToString();
            WrittenNumber = null;
                     
            return this;
        }        

        public virtual DigitGroup AddTensWordsToGroup(DigitGroup group)
        {
            return group;
        }

        public virtual DigitGroup ProcessGroup(DigitGroup group)
        {
            return group;
        }                        

        public List<DigitGroup> SplitInGroups(int absValue)
        {
            Groups = new List<DigitGroup>();            

            NumberString = absValue.ToString();
            char[] chars = NumberString.ToCharArray();
            int groupLength = 0;
            Int32.TryParse(ResourceManager.GetString("groupLength", Culture), out groupLength);
            if (groupLength > 0)
            {
                int charCount = 1;
                string bufferGroup = "";
                int scaleCount = 0;
                for (int i = chars.Length - 1; i >= 0; i--)
                {
                    //prepend char to the group
                    char normalizedChar = chars[i] == '-' ? '0' : chars[i];
                    bufferGroup = normalizedChar + bufferGroup;
                    if (charCount % groupLength == 0)
                    {
                        //must add the group to the list
                        DigitGroup newGroup = new DigitGroup()
                        {
                            Writer = this,
                            UnprocessedValue = bufferGroup,
                            Scale = scaleCount,
                            WrittenNumberSeparator = ResourceManager.GetString("writtenNumberSeparator", Culture)
                        };
                        scaleCount++;
                        Groups.Add(newGroup);
                        //reset the bufferGroup
                        bufferGroup = "";
                    }
                    charCount++;
                }
                if (false == string.IsNullOrEmpty(bufferGroup))
                {
                    //must add the group to the list
                    DigitGroup newGroup = new DigitGroup()
                    {
                        Writer = this,
                        UnprocessedValue = bufferGroup.PadLeft(groupLength, '0'),
                        Scale = scaleCount,
                        WrittenNumberSeparator = ResourceManager.GetString("writtenNumberSeparator", Culture)
                    };
                    scaleCount++;
                    Groups.Add(newGroup);
                }
                return Groups;
            }
            else
                return Groups;
        }

        public DigitGroup AppendScaleToGroup(DigitGroup group)
        {
            if (group == null)
            {
                return group;
            }

            if (group.IntValue != 0)
            {
                switch (group.Scale)
                {
                    case 1: //thousand
                        group.AppendWrittenNumber(ResourceManager.GetString("thousand", Culture));
                        break;
                    case 2: //million
                        group.AppendWrittenNumber(ResourceManager.GetString("million", Culture));
                        break;
                    case 3: //billion
                        group.AppendWrittenNumber(ResourceManager.GetString("billion", Culture));
                        break;
                    default: //hundred or over billion
                        break;
                }
            }

            return group;
        }

        public virtual BasicNumberWriter AddHundredsWordsToGroup(DigitGroup group)
        {
            return this;
        }

        public BasicNumberWriter ProcessAndRecombineGroups()
        {
            List<String> results = new List<String>();
            for (int i = Groups.Count() - 1; i >= 0; i--)
            {
                DigitGroup currentGroup = Groups[i];
                this.ProcessGroup(currentGroup);

                if (false == string.IsNullOrWhiteSpace(currentGroup.WrittenNumber))
                {
                    results.Add(currentGroup.WrittenNumber);
                }
            }

            string separator = ResourceManager.GetString("groupConjunction", Culture)
                + ResourceManager.GetString("writtenNumberSeparator", Culture);
            WrittenNumber = string.Join(separator, results.ToArray());

            return this;

        }

        #endregion Groups

        public string WriteDigit(string digit)
        {
            return ResourceManager.GetString("number" + digit, Culture);
        }

        public virtual BasicNumberWriter PostProcessWrittenNumber()
        {
            if (NegativeNumber)
            {
                WrittenNumber = ResourceManager.GetString("negativeNumberPrefix", Culture) 
                    + ResourceManager.GetString("writtenNumberSeparator", Culture) + WrittenNumber;
            }
            return this;
        }

        public int MinValue = Int32.MinValue;

        public int MaxValue = Int32.MaxValue;
    }
}
