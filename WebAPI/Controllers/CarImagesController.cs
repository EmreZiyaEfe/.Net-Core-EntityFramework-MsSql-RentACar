using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarimagebycarid")]
        public IActionResult GetCarImageByCarId(int id)
        {
            var result = _carImageService.GetCarImageById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarimagebyid")]
        public IActionResult GetCarImageById(int id)
        {
            var result = _carImageService.GetCarImageById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage, [FromForm] IFormFile file)
        {
            //CarImage carImage = new() { CarId = carId };
            var result = _carImageService.Add(file, carImage);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Multiadd")]
        public IActionResult Add([FromForm] int carId, [FromForm] params IFormFile[] files)
        {
            foreach (var file in files)
            {
                var result = _carImageService.Add(file, new CarImage { CarId = carId });
                if (!result.Success)
                {
                    return BadRequest(result);
                }
            }
            return Ok(Messages.CarImageAdded);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            //var deleteCarImage = _carImageService.GetCarImageById(carImage.Id).Data;
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
