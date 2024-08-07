using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 1500, ModelYear = 2023, Descript="2020 Model 1.0 Motor"},
                new Car {CarId = 2, BrandId = 1, ColorId = 1, DailyPrice = 1500, ModelYear = 2023, Descript="2019 Model 1.2 Motor"},
                new Car {CarId = 3, BrandId = 2, ColorId = 2, DailyPrice = 1700, ModelYear = 2023, Descript="2023 Model 1.3 Motor"},
                new Car {CarId = 4, BrandId = 2, ColorId = 3, DailyPrice = 1700, ModelYear = 2023, Descript="2023 Model 1.0 Motor"},
                new Car {CarId = 5, BrandId = 3, ColorId = 1, DailyPrice = 2000, ModelYear = 2023, Descript="2023 Model 1.7 Motor"},

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {

            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        // Where komutu içindeki şarta uyan bütün elemanları yeni liste haline getitirip onu döndürür. SQL'deki where gibi

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Descript = car.Descript;
        }
    }
}
