using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RegistraDll
{
    public class Registrar
    {
        public bool Registar_Dlls(string CaminhoArquivo)
        {
            try
            {
                //'/s' : Specifies regsvr32 to run silently and to not display any message boxes.
                string fileinfo = /*"/s" + " " + */"\"" + CaminhoArquivo + "\"";
                Process reg = new Process();
                //This file registers .dll files as command components in the registry.
                reg.StartInfo.FileName = "regsvr32.exe";
                reg.StartInfo.Arguments = fileinfo;
                reg.StartInfo.UseShellExecute = false;
                reg.StartInfo.CreateNoWindow = true;
                reg.StartInfo.RedirectStandardOutput = true;
                reg.Start();
                reg.WaitForExit();
                reg.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Erro!");
                return false;
            }
        }

        public bool CopiarDll(string Origem, string Destino)
        {
            try
            {       
                File.Copy(Origem, Destino,true);
                return true;
            }       
            catch (Exception copyError)
            {
                MessageBox.Show(copyError.Message);
                return false;
            }
        }

        public bool Reverte_Registro(string CaminhoArquivo)
        {
            try
            {
                //'/s' : Specifies regsvr32 to run silently and to not display any message boxes.
                string fileinfo = "/u" + " " + "\"" + CaminhoArquivo + "\"";
                Process reg = new Process();
                //This file registers .dll files as command components in the registry.
                reg.StartInfo.FileName = "regsvr32.exe";
                reg.StartInfo.Arguments = fileinfo;
                reg.StartInfo.UseShellExecute = false;
                reg.StartInfo.CreateNoWindow = true;
                reg.StartInfo.RedirectStandardOutput = true;
                reg.Start();
                reg.WaitForExit();
                reg.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!");
                return false;
            }
        }


    }
}
