using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using FunctionalProgramming.Extending;

namespace FunctionalProgramming {
    //format: 2018-02-08T12:04;10
    //format: 2018-02-09T13:05;12
    public class DataParser {
        private readonly Dictionary<string, string> _data;

        private DataParser(Dictionary<string, string> data) {
            _data = data;
        }

        public static DataParser CreateFromString(string content) {
            var data = content
                .Split('\n')
                .Select(item => item.Split(';'))
                .ToDictionary(s => s[0], s => s[1]);
            return new DataParser(data);
            /*
            string[] lines = content.Split('\n');
            
            var data = new Dictionary<string, string>();
            foreach (var line in lines) {
                string[] parts = line.Split(';');
                data.Add(parts[0], parts[1]);
            }

            return new DataParser(data);
            */
        }

        public string Value(string timeStamp) {
            string value;
            _data.TryGetValue(timeStamp, out value);
            return value;
        }
    }

    public class Manager {
        public void Process(string timeStamp, bool convertToUtc) {
            /*
            DataParser parser = GetParser();

            string value = parser.Value("2018-02-08T12:04");
            */
            var value = Disposable
                .Using(() => new StreamReader(@"file.csv"),
                    reader => DataParser.CreateFromString(reader.ReadToEnd()))
                .Value(timeStamp)
                .Tee(Console.WriteLine)
                .Map(DateTime.Parse)
                .When(() => convertToUtc, TimeZoneInfo.ConvertTimeToUtc)
                .ToDeviceFormat();
        }

        public void Process2(string timeStamp, bool convertToUtc) {
            DataParser parser;
            using (StreamReader reader = new StreamReader(@"file.csv")) {
                parser = DataParser.CreateFromString(reader.ReadToEnd());
            }
            string value = parser.Value(timeStamp);
            var dt = DateTime.Parse(value);
            if (convertToUtc)
                dt = TimeZoneInfo.ConvertTimeToUtc(dt);
            dt.ToDeviceFormat();
        }


        private static DataParser GetParser() {
            DataParser parser;
            using (StreamReader reader = new StreamReader(@"file.csv")) {
                parser = DataParser.CreateFromString(reader.ReadToEnd());
            }
            return parser;
        }
    }

    public static class Disposable {
        public static TResult Using<TDisposable, TResult>(
            Func<TDisposable> factory,
            Func<TDisposable, TResult> map)
            where TDisposable : IDisposable {
            using (var disposable = factory()) {
                return map(disposable);
            }
        }
    }
}