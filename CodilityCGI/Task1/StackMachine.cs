using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodilityCGI.Task1 {
    public class StackMachine {

        public int solution(String S)
        {
            int value = 0;
            try
            {
                value = (int)Perform(S);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return value;
        }

        private static uint OVERFLOWVALUE = (uint)(Math.Pow(2, 20) - 1);
        private static uint UNDERFLOWVALUE = 0;



        Stack<uint> _MachineStack = new Stack<uint>();

        public uint Perform(string stackCommands)
        {
            _MachineStack.Clear();
            string[] arguments = stackCommands.Split(' ');
            foreach (string argument in arguments)
                PerformCommand(argument);
            return _MachineStack.Pop();
        }

        private void PerformCommand(string argument)
        {
            switch (argument)
            {
                case "POP":
                    Pop();
                    break;
                case "DUP":
                    Duplicate();
                    break;
                case "+":
                    Add();
                    break;
                case "-":
                    Substract();
                    break;
                default:
                    TryPush(argument);
                    break;
            }
        }

        private void TryPush(string argument)
        {
            uint result;
            if (UInt32.TryParse(argument, out result))
                _MachineStack.Push(result);
            else
                throw new InvalidOperationException(String.Format("Operation {0} undefined for this stack machine", argument));
        }

        private void Substract()
        {
            uint argOne = _MachineStack.Pop();
            uint argTwo = _MachineStack.Pop();
            uint result = checked(argOne - argTwo);
            if (result < UNDERFLOWVALUE)
                throw new ArithmeticException("Underflow when substraction");
            _MachineStack.Push(result);
        }

        private void Add()
        {
            uint argOne = _MachineStack.Pop();
            uint argTwo = _MachineStack.Pop();
            uint result = checked(argOne + argTwo);
            if (result > OVERFLOWVALUE)
                throw new ArithmeticException("Overflow when addition");
            _MachineStack.Push(result);
        }

        private void Duplicate()
        {
            uint val = _MachineStack.Pop();
            _MachineStack.Push(val);
            _MachineStack.Push(val);
        }

        private void Pop()
        {
            _MachineStack.Pop();
        }
    }
}
