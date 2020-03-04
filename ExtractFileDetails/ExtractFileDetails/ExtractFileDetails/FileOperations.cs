using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using System.IO;

namespace ExtractFileDetails
{
    public class FileOperations : CodeActivity
    {

        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> FilePath { get; set; }

        public enum addEnum
        {
            GetDirectoryName,
            GetFileName,
            GetFileNameWithoutExtension,
            GetExtension,
            GetSizeInBytes,
            GetLastWriteTime
        }
        [Category("Input")]
        [RequiredArgument]
        public addEnum Operation { get; set; }

        [Category("Output")]
        [RequiredArgument]
        public OutArgument<string> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string filePath = this.FilePath.Get((ActivityContext)context);
            
            var Res = Operation.ToString();
            string Output;
            switch (Res.ToString())
            {
                case "GetDirectoryName":
                    Output = Path.GetDirectoryName(filePath);
                    break;
                case "GetFileName":
                    Output = Path.GetFileName(filePath);
                    break;
                case "GetFileNameWithoutExtension":
                    Output = Path.GetFileNameWithoutExtension(filePath);
                    break;
                case "GetExtension":
                    Output = Path.GetExtension(filePath);
                    break;
                case "GetSizeInBytes":
                    Output = File.ReadAllBytes(filePath).Length.ToString();
                    break;
                case "GetLastWriteTime":
                    Output = File.GetLastWriteTime(filePath).ToString();
                    break;
                default:
                    throw new System.Exception("Invalid Operation Selection");

            }
            Result.Set(context, Output.ToString());

        }
    }
}
