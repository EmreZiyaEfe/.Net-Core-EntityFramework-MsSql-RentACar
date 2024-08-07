// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

//CarTest();
//BrandTest();
//ColorTest();




CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

var result = customerManager.GetCustomerDetails();

if (result.Success == true)
{
    foreach (var customer in result.Data)
    {
        Console.WriteLine("Ad :" + customer.FirstName +"Soyad:" + customer.LastName + "User Id:"+ customer.UserId + "Araç Id:"+customer.CarId);
    }
}











static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());

    var result = carManager.GetCarDetails();

    if (result.Success == true )
    {
        foreach (var car in result.Data)
        {
            Console.WriteLine("Araç ID: " + car.CarId + "  - Günlük Fiyat:" + car.DailyPrice + "  - Marka: " + car.BrandName + "  - Renk: " + car.ColorName);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }


}

static void BrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());

    var result = brandManager.GetAll();

    foreach (var brand in result.Data)
    {
        Console.WriteLine(brand.BrandName);
    }
}

static void ColorTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());
    var result = colorManager.GetAll();
    foreach (var color in result.Data)
    {
        Console.WriteLine(color.ColorName);
    }
}