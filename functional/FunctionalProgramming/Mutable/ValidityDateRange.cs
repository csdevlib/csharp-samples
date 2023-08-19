using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming.Mutable {
    public class ValidityDateRange {        
        public DateTime Start { get ; }
        public DateTime End { get ; }        

        public ValidityDateRange(DateTime start, DateTime end) {
            if(start.CompareTo(end) > 0)
                throw new ArgumentException("End should be ahead of Start or equal.");
            Start = start;
            End = end;
        }

        public bool IsInEffect(DateTime date) {
            return Start.CompareTo(date) <= 0 && End.CompareTo(date) >= 0;
        }

        public ValidityDateRange Extend(int days) {
            return new ValidityDateRange(Start, End.AddDays(days));
        }
    }

    public class Card {
        public string SerialNumber { get; set; }
        public ValidityDateRange Validity { get; set; }
    }

    public class RangeClient {
        public static void Test() {
            var card = new Card() {
                SerialNumber = "123",
                Validity = 
                        new ValidityDateRange(DateTime.Parse("2018-02-01"),
                                              DateTime.Parse("2018-02-10"))                
            };
            var date = DateTime.Parse("2018-02-12");
            bool result1 = card.Validity.IsInEffect(date);

            Console.WriteLine($"Card is in effect? {result1}");

            card.Validity.Extend(6);

            result1 = card.Validity.IsInEffect(date);

            Console.WriteLine($"Card is in effect? {result1}");
            /*
            card.Validity = new ValidityDateRange(
                DateTime.Parse("2018-02-01"),
                DateTime.Parse("2018-02-28"));

            bool result2 = card.Validity.IsInEffect(date);
            Console.WriteLine($"Card is in effect? {result2}");
            */
        }
    }
}