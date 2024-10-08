﻿using Core.Utilities.Helper.FileHelper.Constants;
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
        public string Add(IFormFile file, string root)
        {
            if(file.Length > 0) //file.Length=>Dosya uzunluğunu bayt olarak alır. burada Dosya gönderilmiş mi gönderilmemiş diye test işlemi yapıldı.
            {
                if (!Directory.Exists(root))    // Directory=>System.IO'nın bir class'ı.burada ki işlem tam olarak şu. Bu Add metodumun parametresi olan string root CarManager'dan gelmekte
                {                               //CarImageManager içerisine girdiğinizde buraya parametre olarak *FilePath.ImagesPath* böyle bir şey gönderilidğini görürsünüz. FilePath clası içerisine girdiğinizde string bir ifadeyle bir dizin adresi var
                                                //O adres bizim Yükleyeceğimiz dosyaların kayıt edileceği adres burada *Check if a directory Exists* ifadesi şunu belirtiyor dosyanın kaydedileceği adres dizini var mı? varsa if yapısının kod bloğundan ayrılır eğer yoksa içinde ki kodda dosyaların kayıt edilecek dizini oluşturur    
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName); //Seçmiş olduğumuz dosyanın uzantısını elde ediyoruz.
                string guid = GuidHelper_.CreateGuid();
                string filePath = guid + extension; //Dosyanın oluşturduğum adını ve uzantısını yan yana getiriyorum. Mesela metin dosyası ise .txt gibi bu projemizde resim yükyeceğimiz için .jpg olacak uzantılar 
                using(FileStream fileStream = File.Create(root + filePath)) //Burada en başta FileStrem class'ının bir örneği oluşturulu., sonrasında File.Create(root + newPath)=>Belirtilen yolda bir dosya oluşturur veya üzerine yazar. (root + newPath)=>Oluşturulacak dosyanın yolu ve adı.
                {
                    file.CopyTo(fileStream); //Kopyalanacak dosyanın kopyalanacağı akışı belirtti. yani yukarıda gelen IFromFile türündeki file dosyasının nereye kopyalacağını söyledik.
                    fileStream.Flush(); //Arabellekten siler
                    return filePath; //burada dosyamızın tam adını geri gönderiyoruz sebebide sql servere dosya eklenirken adı ile eklenmesi için.
                }
            }
            return null;
        }

        public void Delete(string filePath) //Burada ki string filePath, 'CarImageManager'dan gelen dosyamın kaydedildiği adres ve adı 
        {
            if (File.Exists(filePath)) //if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath); //Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
        }

        public string Update(IFormFile file, string filePath, string root) //Dosya güncellemek için ise gelen parametreye baktığımızda Güncellenecek yeni dosya, Eski dosyamızın kayıt dizini, ve yeni bir kayıt dizini
        {
            if(!File.Exists(filePath)) // Tekrar if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath); //Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
            return Add(file, root); // Eski dosya silindikten sonra yerine geçecek yeni dosyaiçin alttaki *Add* metoduna yeni dosya ve kayıt edileceği adres parametre olarak döndürülüyor.
        }
    }
}
//IFormFile projemize bir dosya yüklemek için kulanılan yöntemdir, HttpRequest ile gönderilen bir dosyayı temsil eder.
//FileStream, Stream ana soyut sınıfı kullanılarak genişletilmiş, belirtilen kaynak dosyalar üzerinde okuma/yazma/atlama gibi operasyonları yapmamıza yardımcı olan bir sınıftır