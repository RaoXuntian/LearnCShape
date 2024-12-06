using System;

[assembly: CLSCompliant(true)]
namespace HelloWorld
{
    public sealed class ClsDemo
    {
        public UInt32 Abc() { return 0; }

        public void abc() { }

        private UInt32 ABC() { return 0; }
    }

    public class ClsTest
    {
        public ClsTest() { }

        ~ClsTest() { }

        public static Boolean operator ==(ClsTest a, ClsTest b) { return true; }

        public static Boolean operator !=(ClsTest a, ClsTest b) { return false; }

        public String AProperty
        {
            get { return null; }
            set { }
        }

        public String this[Int32 x]
        {
            get { return null; }
            set { }
        }

        event EventHandler AnEvent;
    }
}
