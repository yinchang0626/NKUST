using ConsoleApp.Models;

namespace ConsoleApp.Services
{
    //public interface IImportService
    //{
    //    List<object> LoadFormFile(string filePath);
    //}

    public interface IImportService<T>
        where T : class
    {
        new List<T> LoadFormFile(string filePath);

        List<T> Filter(List<T> datas);

        bool SaveFormFile(string filePath);

        void Display(List<T> datas);
    }
}