using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/* 
 * Done By Asbjørn Birch
 */
 
/*The idea of this class, is to create a Debugger.txt 
 * to write all the Exeptions, that different methods 
 * will throw. This is done for later debugging
 */
namespace itn0912_2DBLayer.Debug
{
    public class DebugToTxt
    {

        public static void DebugMethod(string error)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Debug.txt", true))
            {
                file.WriteLine("\r\nLog Entry : ");
                file.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                file.WriteLine("Error Message: ");
                file.WriteLine(error);
                file.WriteLine("-----------------------------------------------------------");
            }  
        }
        
    }
}
