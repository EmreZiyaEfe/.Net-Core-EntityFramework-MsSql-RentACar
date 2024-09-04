using Core.Utilities.Helper.FileHelper.Constants;
using Core.Utilities.Helper.GuidHelp;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public string Add(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName); // dosya uzantısı alındı
            string uniqueFileName = GuidHelper_.Create() + fileExtension; // guid ile uzantı birleşti;
            var imagePath = FilePath.Full(uniqueFileName); // kaydetmek istenilen yerin tam yolu alındı
            using FileStream fileStream = new(imagePath, FileMode.Create); //yeni bir dosya oluşturması gerek, dosya varsa üzerine yazar
            file.CopyTo(fileStream); // yolu kopyalar
            fileStream.Flush();   // ara belleği temizler
            return uniqueFileName;
        }

        public void Delete(string Path)
        {
            throw new NotImplementedException();
        }

        public void Update(IFormFile file, string imagePath)
        {
            throw new NotImplementedException();
        }
    }
}
