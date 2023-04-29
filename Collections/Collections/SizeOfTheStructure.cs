using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class SizeOfTheStructure
    {
        public static int GetSize<T>()
        {
            Type tt = typeof(T);
            int size;
            if (tt.IsValueType)
            {
                if (tt.IsGenericType)
                {
                    var t = default(T);
                    size = Marshal.SizeOf(t);
                }
                else
                {
                    size = Marshal.SizeOf(tt);
                }
            }
            else
            {
                size = IntPtr.Size;
            }
            return size;
        }        
    }
}
