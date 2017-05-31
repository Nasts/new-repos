using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace mantis_tests
{
    public class FtpHelper: HelperBase
    {
        //конструктор
        public FtpHelper(ApplicationManager manager) : base(manager) { }

        //временно спрятать существующий конф файл 
        public void BackupFile(String path)
        {

        }

        //восстанавливать конф файл
        public void RestoreBackupFile(String path)
        {
               
        }

        public void Upload(String path, File localFile)
        {

        }


    }
}
