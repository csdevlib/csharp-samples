using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming.Immutable {
    public interface IStack<T> : IEnumerable<T> {
        IStack<T> Push(T value);
        IStack<T> Pop();
        T Peek();
        bool IsEmpty { get; }
    }

    public sealed class Stack<T> : IStack<T> {
        private sealed class EmptyStack : IStack<T> {
            public bool IsEmpty => true;

            public T Peek() {
                throw new Exception("Empty stack");
            }

            public IStack<T> Push(T value) {
                return new Stack<T>(value, this);
            }

            public IStack<T> Pop() {
                throw new Exception("Empty stack");
            }

            public IEnumerator<T> GetEnumerator() {
                yield break;
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return this.GetEnumerator();
            }
        }

        private static readonly EmptyStack empty = new EmptyStack();

        public static IStack<T> Empty => empty;

        private readonly T _head;
        private readonly IStack<T> _tail;

        private Stack(T head, IStack<T> tail) {
            _head = head;
            _tail = tail;
        }

        public bool IsEmpty => false;

        public T Peek() {
            return _head;
        }

        public IStack<T> Pop() {
            return _tail;
        }

        public IStack<T> Push(T value) {
            return new Stack<T>(value, this);
        }

        public IEnumerator<T> GetEnumerator() {
            for (IStack<T> stack = this; !stack.IsEmpty; stack = stack.Pop())
                yield return stack.Peek();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
    }
}