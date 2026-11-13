using System.IO;

namespace KooliProjekt.Application.Infrastructure.Files
{
    public static class FileStore
    {
        public const string Photos = "photos";
        public const string Invoices = "invoices";
        public const string Cars = "cars";

        public static string ForCar(int carId)
        {
            return Path.Combine(Cars, carId.ToString());
        }
    }
}
