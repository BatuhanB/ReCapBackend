using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper.Concrete
{
    public static class FileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\Images\\";
        public static IResult Upload(IFormFile file)
        {
            var result = CheckIfFileExists(file);
            if (result.Message != null)
            {
                return new ErrorResult(result.Message);
            }
            var type = Path.GetExtension(file.FileName);//gelen dosyanın uzantısını alıyoruz
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid.Message != null)
            {
                return new ErrorResult(typeValid.Message);
            }
            CheckIfDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }
        public static IResult Delete(string imagePath)
        {
            DeleteOldImageFile((_currentDirectory + imagePath).Replace("/","\\"));
            return new SuccessResult();
        }

        public static IResult Update(IFormFile file, string imagePath)
        {
            var result = CheckIfFileExists(file);
            if (result != null)
            {
                return result;
            }
            var type = Path.GetExtension(file.FileName);//gelen dosyanın uzantısını alıyoruz
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();
            var fileName = randomName + type;

            if (typeValid != null)
            {
                return typeValid;
            }
            DeleteOldImageFile((_currentDirectory + imagePath).Replace("/", "\\"));
            CheckIfDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }

        private static IResult CheckIfFileExists(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("File doesn't exists.");
        }
        private static IResult CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorResult("Wrong file type.");
            }
            return new SuccessResult();
        }

        private static void CheckIfDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        private static void CreateImageFile(string fileDirectory, IFormFile file)
        {
            using var fileStream = File.Create(fileDirectory);
            file.CopyTo(fileStream);
            fileStream.Flush();
        }
        private static void DeleteOldImageFile(string fileDirectory)
        {
            if (File.Exists(fileDirectory.Replace("/", "\\")))
            {
                File.Delete(fileDirectory.Replace("/", "\\"));
            }
        }
    }
}
