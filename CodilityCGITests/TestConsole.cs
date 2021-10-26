using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityCGITests {
    static class TestConsole {

        public static void Write(string message) => System.Diagnostics.Trace.Write(message);

        public static void WriteLine(string message) => System.Diagnostics.Trace.WriteLine(message);
    }
}
