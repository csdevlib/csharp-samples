using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming {
    public static class GeneralExtensions {
        public static T Tee<T>(this T @this, Action<T> action) {
            action(@this);
            return @this;
        }

        public static TResult Map<TSource, TResult>(
            this TSource @this,
            Func<TSource, TResult> map) => map(@this);

        public static T When<T>(
            this T @this,
            Func<bool> predicate,
            Func<T, T> fn) =>
            predicate()
                ? fn(@this)
                : @this;

    }
}