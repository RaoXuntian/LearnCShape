using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    public class GenGuid
    {
        private Guid G { get; set; }
        public GenGuid()
        {
            Guid g = Guid.NewGuid();
            G = g;
        }
        public void GenGuid2()
        {
            
            Console.WriteLine(G);
            
            //Console.WriteLine(Guid.NewGuid());
        }
        
        public Guid SetGuid()
        {
            return G;
        }

        public Guid SetGuidRandom()
        {
            return Guid.NewGuid();
        }
    }
}
