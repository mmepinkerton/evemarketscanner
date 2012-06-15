using System;
using System.Collections.Generic;
using System.Text;

namespace MarketScanner.Common
{
    // Generic type of pairs
    class Tuple<Type1, Type2>
    {
        private Type1 m_t1;
        private Type2 m_t2;

        public Type1 First
        {
            get { return m_t1; }
            set { m_t1 = value; }
        }

        public Type2 Second
        {
            get { return m_t2; }
            set { m_t2 = value; }
        }

        public Tuple() { }

        public Tuple( Type1 t1, Type2 t2 )
        {
            m_t1 = t1;
            m_t2 = t2;
        }
    }
}
