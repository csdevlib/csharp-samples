using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalProgramming {
    public class TravelInfo {
        public string Name { get; set; }
        public string CardInfo { get; set; }
        public string Reason { get; set; }
    }

    public class TravelInfoViewModel {
        public TravelInfo TravelInfo { get; }
        private List<string> terminalInfo;

        public void Finish() {
            string report = ReportFactory.CreateFinalReport(terminalInfo, TravelInfo);
            Console.WriteLine(report);
        }
    }

    public class ReportFactory {
        public static string CreateFinalReport(List<string> terminalInfo, TravelInfo info) {
            return new StringBuilder()
                .AppendFormattedLine("Name = {0}", info.Name)
                .When(() => Validate(info.CardInfo),
                    failure: builder => builder.AppendFormattedLine("Card {0} is validated.", info.CardInfo),
                    success: builder => builder.AppendFormattedLine("Card validation failed."))
                .AppendFormattedLine("Reason is {0}", info.Reason)
                .AppendSequence(terminalInfo,
                    (builder, current) =>
                        builder.AppendFormattedLine("Terminal Info Record = {0}", current))
                .ToString();                        
        }

        private static bool Validate(string infoCardInfo) {
            return new Random().Next(0, 1) == 1;
        }
    }
}