using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalProgramming {
    public static class StringBuilderExtensions {
        public static StringBuilder AppendFormattedLine(
            this StringBuilder @this,
            string format,
            params object[] args) =>
            @this.AppendFormat(format, args).AppendLine();

        public static StringBuilder AppendSequence<T>(
            this StringBuilder @this,
            IEnumerable<T> sequence,
            Func<StringBuilder, T, StringBuilder> fn) =>
                sequence.Aggregate(@this, fn);
    }
}