using ConsoleTools;
using F19FKP_HFT_2023242.Models;
using System;

namespace F19FKP_HFT_2023242.Client
{
    class Program
    {
        static RestService RestService;
        static void Main(string[] args)
        {
            RestService = new RestService("http://localhost:14582/", "Brand");
            CrudService crud = new CrudService(RestService);
            NonCrudService noncrud = new NonCrudService(RestService);

            var BrandMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Brand>())
                .Add("Create", () => crud.Create<Brand>())
                .Add("Delete", () => crud.Delete<Brand>())
                .Add("Update", () => crud.Update<Brand>())
                .Add("Exit", ConsoleMenu.Close);
            var CarMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Car>())
                .Add("Create", () => crud.Create<Car>())
                .Add("Delete", () => crud.Delete<Car>())
                .Add("Update", () => crud.Update<Car>())
                .Add("Exit", ConsoleMenu.Close);
            var RepairMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Repair>())
                .Add("Create", () => crud.Create<Repair>())
                .Add("Delete", () => crud.Delete<Repair>())
                .Add("Update", () => crud.Update<Repair>())
                .Add("Exit", ConsoleMenu.Close);
            var NonCrudMenu = new ConsoleMenu(args, level: 1)
                .Add("RepairsFromYear", () => noncrud.RepairsFromYear())
                .Add("AllCarsFromBrand", () => noncrud.AllCarsFromBrand())
                .Add("CarsByColor", () => noncrud.CarsByColor())
                .Add("MostExpensiveRepairFromBrand", () => noncrud.MostExpensiveRepairFromBrand())
                .Add("SameWheelDriveCars", () => noncrud.SameWheelDriveCars())
                .Add("Exit", ConsoleMenu.Close);
            var menu = new ConsoleMenu(args, level: 0)
                .Add("Brands", () => BrandMenu.Show())
                .Add("Cars", () => CarMenu.Show())
                .Add("Repairs", () => RepairMenu.Show())
                .Add("NonCrud", () => NonCrudMenu.Show());
            menu.Show();
        }
    }
}