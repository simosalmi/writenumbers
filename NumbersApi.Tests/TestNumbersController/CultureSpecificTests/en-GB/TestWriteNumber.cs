using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using NumbersApi.Controllers;
using NumbersApi.Models;
using System.Web.Http.Results;
using NumbersApi.Models.Interfaces;

namespace NumbersApi.Tests.TestNumbersController.CultureSpecificTests.En.Gb
{
    [TestClass]
    public class TestWriteNumber
    {
        public string CultureName = "en-GB";
        
        #region API Tests
        [TestMethod]
        public void should_return_zero_if_number_is_0()
        {
            //Arrange
            var controller = new NumbersController();
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "0",
                CultureName = this.CultureName
            };

            //Act
            var controllerResult = controller.WriteNumber(options);
            var result = controllerResult as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Content.Error);
            Assert.AreEqual("zero", result.Content.Value);
            Assert.AreEqual(options.CultureName, result.Content.CultureName);
        }

        [TestMethod]
        public void negative_numbers_are_preceded_by_the_word_negative()
        {
            //Arrange
            var controller = new NumbersController();
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "-108",
                CultureName = this.CultureName
            };

            //Act
            var result = controller.WriteNumber(options) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Content.Error);
            Assert.IsTrue(result.Content.Value.StartsWith("negative"));
            Assert.AreEqual(options.CultureName, result.Content.CultureName);
        }

        [TestMethod]
        public void write_numbers_to_twelve()
        {
            //Arrange
            var controller = new NumbersController();
            
            NumberWriterOptions options1 = new NumberWriterOptions()
            {
                Value = "1",
                CultureName = this.CultureName
            };

            //Act
            var result1 = controller.WriteNumber(options1) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result1);
            Assert.IsNull(result1.Content.Error);            
            Assert.AreEqual(options1.CultureName, result1.Content.CultureName);
            Assert.AreEqual(result1.Content.Value, "one");

            NumberWriterOptions options2 = new NumberWriterOptions()
            {
                Value = "2",
                CultureName = this.CultureName
            };

            //Act
            var result2 = controller.WriteNumber(options2) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result2);
            Assert.IsNull(result2.Content.Error);
            Assert.AreEqual(options2.CultureName, result2.Content.CultureName);
            Assert.AreEqual(result2.Content.Value, "two");

            NumberWriterOptions options3 = new NumberWriterOptions()
            {
                Value = "3",
                CultureName = this.CultureName
            };

            //Act
            var result3 = controller.WriteNumber(options3) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result3);
            Assert.IsNull(result3.Content.Error);
            Assert.AreEqual(options3.CultureName, result3.Content.CultureName);
            Assert.AreEqual(result3.Content.Value, "three");

            NumberWriterOptions options4 = new NumberWriterOptions()
            {
                Value = "4",
                CultureName = this.CultureName
            };

            //Act
            var result4 = controller.WriteNumber(options4) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result4);
            Assert.IsNull(result4.Content.Error);
            Assert.AreEqual(options4.CultureName, result4.Content.CultureName);
            Assert.AreEqual(result4.Content.Value, "four");

            NumberWriterOptions options5 = new NumberWriterOptions()
            {
                Value = "5",
                CultureName = this.CultureName
            };

            //Act
            var result5 = controller.WriteNumber(options5) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result5);
            Assert.IsNull(result5.Content.Error);
            Assert.AreEqual(options5.CultureName, result5.Content.CultureName);
            Assert.AreEqual(result5.Content.Value, "five");

            NumberWriterOptions options6 = new NumberWriterOptions()
            {
                Value = "6",
                CultureName = this.CultureName
            };

            //Act
            var result6 = controller.WriteNumber(options6) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result6);
            Assert.IsNull(result6.Content.Error);
            Assert.AreEqual(options6.CultureName, result6.Content.CultureName);
            Assert.AreEqual(result6.Content.Value, "six");

            NumberWriterOptions options7 = new NumberWriterOptions()
            {
                Value = "7",
                CultureName = this.CultureName
            };

            //Act
            var result7 = controller.WriteNumber(options7) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result7);
            Assert.IsNull(result7.Content.Error);
            Assert.AreEqual(options7.CultureName, result7.Content.CultureName);
            Assert.AreEqual(result7.Content.Value, "seven");

            NumberWriterOptions options8 = new NumberWriterOptions()
            {
                Value = "8",
                CultureName = this.CultureName
            };

            //Act
            var result8 = controller.WriteNumber(options8) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result8);
            Assert.IsNull(result8.Content.Error);
            Assert.AreEqual(options8.CultureName, result8.Content.CultureName);
            Assert.AreEqual(result8.Content.Value, "eight");

            NumberWriterOptions options9 = new NumberWriterOptions()
            {
                Value = "9",
                CultureName = this.CultureName
            };

            //Act
            var result9 = controller.WriteNumber(options9) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result9);
            Assert.IsNull(result9.Content.Error);
            Assert.AreEqual(options9.CultureName, result9.Content.CultureName);
            Assert.AreEqual(result9.Content.Value, "nine");

            NumberWriterOptions options10 = new NumberWriterOptions()
            {
                Value = "10",
                CultureName = this.CultureName
            };

            //Act
            var result10 = controller.WriteNumber(options10) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result10);
            Assert.IsNull(result10.Content.Error);
            Assert.AreEqual(options10.CultureName, result10.Content.CultureName);
            Assert.AreEqual(result10.Content.Value, "ten");

            NumberWriterOptions options11 = new NumberWriterOptions()
            {
                Value = "11",
                CultureName = this.CultureName
            };

            //Act
            var result11 = controller.WriteNumber(options11) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result11);
            Assert.IsNull(result11.Content.Error);
            Assert.AreEqual(options11.CultureName, result11.Content.CultureName);
            Assert.AreEqual(result11.Content.Value, "eleven");

            NumberWriterOptions options12 = new NumberWriterOptions()
            {
                Value = "12",
                CultureName = this.CultureName
            };

            //Act
            var result12 = controller.WriteNumber(options12) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result12);
            Assert.IsNull(result12.Content.Error);
            Assert.AreEqual(options12.CultureName, result12.Content.CultureName);
            Assert.AreEqual(result12.Content.Value, "twelve");

        }

        [TestMethod]
        public void twenty_one_results_from_21()
        {
            //Arrange
            var controller = new NumbersController();

            NumberWriterOptions options1 = new NumberWriterOptions()
            {
                Value = "21",
                CultureName = this.CultureName
            };

            //Act
            var result1 = controller.WriteNumber(options1) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result1);
            Assert.IsNull(result1.Content.Error);
            Assert.AreEqual(options1.CultureName, result1.Content.CultureName);
            Assert.AreEqual(result1.Content.Value, "twenty one");
        }

        [TestMethod]
        public void one_hundred_and_five_results_from_105()
        {
            //Arrange
            var controller = new NumbersController();

            NumberWriterOptions options1 = new NumberWriterOptions()
            {
                Value = "105",
                CultureName = this.CultureName
            };

            //Act
            var result1 = controller.WriteNumber(options1) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result1);
            Assert.IsNull(result1.Content.Error);
            Assert.AreEqual(options1.CultureName, result1.Content.CultureName);
            Assert.AreEqual(result1.Content.Value, "one hundred and five");
        }

        [TestMethod]
        public void fifty_six_million_nine_hundred_and_forty_five_thousand_seven_hundred_and_eighty_one_results_from_56945781()
        {
            //Arrange
            var controller = new NumbersController();

            NumberWriterOptions options1 = new NumberWriterOptions()
            {
                Value = "56945781",
                CultureName = this.CultureName
            };

            //Act
            var result1 = controller.WriteNumber(options1) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result1);
            Assert.IsNull(result1.Content.Error);
            Assert.AreEqual(options1.CultureName, result1.Content.CultureName);
            Assert.AreEqual(result1.Content.Value, "fifty six million, nine hundred and forty five thousand, seven hundred and eighty one");
        }

        [TestMethod]
        public void negative_nine_hundred_and_ninety_nine_million_nine_hundred_and_ninety_nine_thousand_nine_hundred_and_ninety_nine_results_from_minus_999999999()
        {
            //Arrange
            var controller = new NumbersController();

            NumberWriterOptions options1 = new NumberWriterOptions()
            {
                Value = "-999999999",
                CultureName = this.CultureName
            };

            //Act
            var result1 = controller.WriteNumber(options1) as OkNegotiatedContentResult<NumberWriterResult>;

            //Assert
            Assert.IsNotNull(result1);
            Assert.IsNull(result1.Content.Error);
            Assert.AreEqual(options1.CultureName, result1.Content.CultureName);
            Assert.AreEqual(result1.Content.Value, "negative nine hundred and ninety nine million, nine hundred and ninety nine thousand, nine hundred and ninety nine");
        }

        #endregion API Tests

        #region En-Gb Writer Tests
        [TestMethod]
        public void should_split_in_groups_of_three_digits_starting_from_right()
        {
            //Arrange            
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "1234567890",
                CultureName = this.CultureName
            };

            //Act            
            EnGbNumberWriter writer = new EnGbNumberWriter();
            var groups = writer.SplitInGroups(Int32.Parse(options.Value));

            //Assert
            Assert.IsNotNull(groups);            
            Assert.AreEqual(4, groups.Count());
            for(var i = 0; i < groups.Count(); i++)
            {
                string result = groups[i].UnprocessedValue;
                if(i == groups.Count() - 1)
                {
                    Assert.AreEqual(3, result.Length);
                    Assert.IsTrue(result[0] == '0' && result[1] == '0');
                }
                else
                {
                    Assert.AreEqual(3, result.Length);
                }
            }            
        }

        [TestMethod]
        public void should_append_once_the_relevant_scale_number_to_groups_if_needed()
        {
            //Arrange            
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "1234567890",
                CultureName = this.CultureName
            };

            //Act
            EnGbNumberWriter writer = new EnGbNumberWriter();
            var groups = writer.SplitInGroups(int.Parse(options.Value));

            //Assert
            Assert.IsNotNull(groups);
            for (var i = 0; i < groups.Count(); i++)
            {
                string stringToSearch = null;
                
                switch(i) {
                    case 1: //thousand
                        stringToSearch = "thousand";
                        break;
                    case 2: //million
                        stringToSearch = "million";
                        break;
                    case 3: //billion
                        stringToSearch = "billion";
                        break;
                    default: //hundred or over billion
                        continue;                        
                }
                var processedGroup = writer.AppendScaleToGroup(groups[i]);
                Assert.IsTrue(processedGroup.WrittenNumber.EndsWith(stringToSearch));
                Assert.IsTrue(processedGroup.WrittenNumber.IndexOf(stringToSearch) == processedGroup.WrittenNumber.LastIndexOf(stringToSearch));
            }
        }

        [TestMethod]
        public void if_the_hundreds_portion_of_a_group_is_not_zero_the_number_of_hundreds_is_added_to_the_word_and_viceversa()
        {
            //Arrange            
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "1400000021",
                CultureName = this.CultureName
            };

            //Act
            EnGbNumberWriter writer = new EnGbNumberWriter();
            var groups = writer.SplitInGroups(int.Parse(options.Value));

            //Assert
            Assert.IsNotNull(groups);
            foreach(var group in groups)
            {
                group.AddHundredsWords();
                
                char hundreds = group.UnprocessedValue[0];
                var hundredsWritten = writer.WriteDigit(hundreds.ToString());
                if(Int32.Parse(hundreds.ToString()) != 0)
                {
                    Assert.IsTrue(group.WrittenNumber.Contains(hundredsWritten + " hundred"));
                }
                else
                {                    
                    Assert.IsTrue(string.IsNullOrEmpty(group.WrittenNumber) || false == group.WrittenNumber.Contains(" hundred"));                    
                }
            }
        }
        
        [TestMethod]
        public void if_the_group_is_exactly_divisible_by_one_hundred_then_the_text_hundred_is_appended_otherwise_hundred_and()
        {
            //Arrange            
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "200450400",
                CultureName = this.CultureName
            };

            //Act
            EnGbNumberWriter writer = new EnGbNumberWriter();
            var groups = writer.SplitInGroups(int.Parse(options.Value));

            //Assert
            Assert.IsNotNull(groups);
            foreach (var group in groups)
            {
                group.AddHundredsWords();
                
                string hundreds = group.UnprocessedValue[0].ToString();
                var hundredsWritten = writer.WriteDigit(hundreds);

                string stringToSearch = "";
                if(Int32.Parse(group.UnprocessedValue) % 100 == 0)
                {
                    stringToSearch = " hundred";
                }
                else
                {
                    stringToSearch = " hundred and";
                }
                Assert.IsTrue(group.WrittenNumber.Contains(stringToSearch));
                Assert.IsTrue(group.WrittenNumber.LastIndexOf(stringToSearch) == group.WrittenNumber.IndexOf(stringToSearch));
            }
        }

        [TestMethod]
        public void if_the_tens_and_the_units_of_a_group_are_both_zero_no_text_is_added()
        {
            //Arrange            
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "500123",
                CultureName = this.CultureName
            };

            //Act
            EnGbNumberWriter writer = new EnGbNumberWriter();
            var groups = writer.SplitInGroups(int.Parse(options.Value));

            //Assert
            Assert.IsNotNull(groups);
            foreach (var group in groups)
            {
                var originalValue = group.WrittenNumber ?? "";
                group.AddTensWords();                
                
                string tens = group.UnprocessedValue[1].ToString();
                string units = group.UnprocessedValue[2].ToString();
                if (tens == "0" && units == "0")
                {
                    Assert.AreEqual(originalValue, group.WrittenNumber ?? "");
                }                
            }
        }

        [TestMethod]
        public void if_the_tens_section_of_a_group_is_two_or_higher_the_appropriate_ty_word_is_added_followed_by_the_name_of_the_third_digit_unless_this_is_zero()
        {
            //Arrange            
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "1270014890",
                CultureName = this.CultureName
            };

            //Act
            EnGbNumberWriter writer = new EnGbNumberWriter();
            var groups = writer.SplitInGroups(int.Parse(options.Value));

            //Assert
            Assert.IsNotNull(groups);
            foreach (var group in groups)
            {
                group.AddTensWords();                

                int tens = group.Digits[1];
                string units = group.UnprocessedValue[2].ToString();

                if(tens >= 2)
                {
                    string stringToSearch = null;                    
                    if(Int32.Parse(units) == 0)
                    {                        
                        stringToSearch = "ty";
                    }
                    else
                    {
                        stringToSearch = "ty " + writer.WriteDigit(units);
                    }
                    Assert.IsTrue(group.WrittenNumber.Contains(stringToSearch));
                    Assert.IsTrue(group.WrittenNumber.IndexOf(stringToSearch) == group.WrittenNumber.LastIndexOf(stringToSearch));
                }                
            }
        }

        [TestMethod]
        public void if_the_tens_section_of_a_group_is_less_than_two_and_not_equal_to_zero_the_correct_name_is_given()
        {
            //Arrange            
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "1119018614",
                CultureName = this.CultureName
            };

            //Act
            EnGbNumberWriter writer = new EnGbNumberWriter();
            var groups = writer.SplitInGroups(int.Parse(options.Value));

            //Assert
            Assert.IsNotNull(groups);
            foreach (var group in groups)
            {
                group.AddTensWords();                

                string tens = group.UnprocessedValue[1].ToString();
                int intTens = Int32.Parse(tens);
                string units = group.UnprocessedValue[2].ToString();

                if (intTens != 0 && intTens < 2)
                {
                    string stringToSearch = null;
                    string tensUnits = tens + units;
                    switch(tensUnits)
                    {
                        case "10":
                            stringToSearch = "ten";
                            break;
                        case "11":
                            stringToSearch = "eleven";
                            break;
                        case "12":
                            stringToSearch = "twelve";
                            break;
                        case "13":
                            stringToSearch = "thirteen";
                            break;
                        case "14":
                            stringToSearch = "fourteen";
                            break;
                        case "15":
                            stringToSearch = "fifteen";
                            break;
                        case "16":
                            stringToSearch = "sixteen";
                            break;
                        case "17":
                            stringToSearch = "seventeen";
                            break;
                        case "18":
                            stringToSearch = "eighteen";
                            break;
                        case "19":
                            stringToSearch = "nineteen";
                            break;
                    }
                    Assert.IsTrue(group.WrittenNumber.Contains(stringToSearch));
                    Assert.IsTrue(group.WrittenNumber.IndexOf(stringToSearch) == group.WrittenNumber.LastIndexOf(stringToSearch));
                }
            }
        }

        [TestMethod]
        public void combining_hundreds_and_tens_there_are_no_additional_whitespaces()
        {            
            //Arrange            
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "1119018614",
                CultureName = this.CultureName
            };

            //Act
            EnGbNumberWriter writer = new EnGbNumberWriter();
            var groups = writer.SplitInGroups(int.Parse(options.Value));

            //Assert
            Assert.IsNotNull(groups);
            foreach (var group in groups)
            {
                group.AddHundredsWords().AddTensWords();

                Assert.IsFalse(group.WrittenNumber.Contains("  "));
            }
        }
        
        [TestMethod]
        public void when_recombining_groups_each_group_except_the_last_is_followed_by_a_comma_unless_the_group_is_blank()
        {
            //Arrange            
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "1119000614",
                CultureName = this.CultureName
            };

            //Act
            EnGbNumberWriter writer = new EnGbNumberWriter();
            var groups = writer.SplitInGroups(int.Parse(options.Value));            
            
            string processedWrittenNumber = writer.ProcessAndRecombineGroups().WrittenNumber;
            string recombinedGroups = "";

            for (int i = groups.Count() - 1; i >= 0; i-- )
            {
                if(groups[i].UnprocessedValue != "000")
                {
                    recombinedGroups += groups[i].WrittenNumber + ", ";
                }
            }
            recombinedGroups = recombinedGroups.Substring(0, recombinedGroups.Length - 2);

            //Assert
            //Each non blank group is followed by a comma
            Assert.IsNotNull(groups);
            Assert.AreEqual(processedWrittenNumber, recombinedGroups);
            Assert.IsFalse(processedWrittenNumber.Contains(",,"));
            Assert.IsFalse(processedWrittenNumber.Contains(", , "));
        }

        [TestMethod]
        public void when_recombining_groups_each_group_except_the_last_is_followed_by_a_large_number_name_unless_the_group_is_blank()
        {
            //Arrange            
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "1119000614",
                CultureName = this.CultureName
            };

            //Act
            EnGbNumberWriter writer = new EnGbNumberWriter();
            var groups = writer.SplitInGroups(int.Parse(options.Value));

            string processedWrittenNumber = writer.ProcessAndRecombineGroups().WrittenNumber;
            
            List<String> splittedResult = processedWrittenNumber.Split(',').ToList<String>();
            // first tens, hundreds...
            splittedResult.Reverse();

            Assert.IsNotNull(groups);

            int emptyGroups = 0;
            
            for(int i = 0; i< groups.Count(); i++)
            {
                DigitGroup group = groups[i];
                if (group.UnprocessedValue != "000")
                {
                    //Assert
                    //Each non blank group is followed by a large number name
                    switch(group.Scale)
                    {
                        case 0:
                            //hundred - no name                            
                            Assert.IsFalse(splittedResult[i - emptyGroups].EndsWith("thousand"));
                            Assert.IsFalse(splittedResult[i - emptyGroups].EndsWith("million"));
                            Assert.IsFalse(splittedResult[i - emptyGroups].EndsWith("billion"));
                            break;
                        case 1:
                            //thousand
                            Assert.IsTrue(splittedResult[i - emptyGroups].EndsWith("thousand"));                           
                            break;
                        case 2:
                            //million
                            Assert.IsTrue(splittedResult[i - emptyGroups].EndsWith("million"));
                            break;
                        case 3:
                            //billion
                            Assert.IsTrue(splittedResult[i - emptyGroups].EndsWith("billion"));
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    emptyGroups++;
                }
            }
            
        }

        [TestMethod]
        public void when_recombining_groups_the_blank_groups_are_not_included()
        {
            //Arrange            
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "1119000614",
                CultureName = this.CultureName
            };

            //Act
            EnGbNumberWriter writer = new EnGbNumberWriter();
            var groups = writer.SplitInGroups(int.Parse(options.Value));

            //Assert
            Assert.IsNotNull(groups);
            string recombinedGroups = writer.ProcessAndRecombineGroups().WrittenNumber;
            foreach (var group in groups)
            {                
                if(group.UnprocessedValue == "000")
                {
                    Assert.IsTrue(string.IsNullOrEmpty(group.WrittenNumber));
                }
            }
        }

        [TestMethod]
        public void when_recombining_groups_a_comma_is_always_followed_by_a_white_space()
        {
            //Arrange            
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "1119000614",
                CultureName = this.CultureName
            };

            //Act
            EnGbNumberWriter writer = new EnGbNumberWriter();
            var groups = writer.SplitInGroups(int.Parse(options.Value));

            //Assert
            Assert.IsNotNull(groups);
            string recombinedGroups = writer.ProcessAndRecombineGroups().WrittenNumber;
            for (int i = 0; i < recombinedGroups.Count(); i++ )
            {
                char c = recombinedGroups[i];
                if (c == ',')
                {
                    Assert.IsTrue(recombinedGroups[i + 1] == ' ');
                }
            }
        }

        [TestMethod]
        public void when_the_final_group_does_not_include_any_hundreds_and_there_is_more_than_one_non_blank_group_the_final_comma_is_replaced_with_and()
        {
            //Arrange            
            NumberWriterOptions options = new NumberWriterOptions()
            {
                Value = "1001000012",
                CultureName = this.CultureName
            };

            //Act
            EnGbNumberWriter writer = new EnGbNumberWriter();
            
            string result = writer.Write(options).WrittenNumber;
            //Assert
            Assert.AreEqual("one billion, one million and twelve", result);            
        }

        [TestMethod]
        public void written_negative_numbers_are_the_same_as_positive_numbers_except_for_the_negative_word_at_the_beginning()
        {
            //Arrange            
            NumberWriterOptions optionsNegative = new NumberWriterOptions()
            {
                Value = "-1001000012",
                CultureName = this.CultureName
            };

            //Act
            EnGbNumberWriter writer = new EnGbNumberWriter();

            string resultNegative = writer.Write(optionsNegative).WrittenNumber;

            NumberWriterOptions optionsPositive = new NumberWriterOptions()
            {
                Value = "1001000012",
                CultureName = this.CultureName
            };

            //Act
            EnGbNumberWriter writerPositive = new EnGbNumberWriter();

            string resultPositive = writerPositive.Write(optionsPositive).WrittenNumber;

            //Assert
            Assert.AreEqual("negative " + resultPositive, resultNegative);
        }
        
        #endregion En-Gb Writer Tests       

    }
}
