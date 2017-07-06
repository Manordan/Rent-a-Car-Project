using CarSite.Models;
using CarSite.ViewModel;
using System;
using System.Linq;
using System.Web.Http;

namespace CarSite.Api
{



    public class SearchController : ApiController
    {
        CarContext _carContext;
        public SearchController()
        {
            _carContext = new CarContext();
        }
       
        public IHttpActionResult Get()
        {
            try
            {
                var car = _carContext.CarManufacturers.OrderBy(m=> m.Name).Select(x => new CarManufacturerDto
                {
                    Id=x.Id,
                    Name = x.Name,
                    Model= x.CarModels.OrderBy(d=> d.Model).Select(m=> new CarModelDto {
                        Id=m.Id,
                        Model=m.Model

                    })
                    
                }
                ).ToList();

   
                return Ok(car);

            }
            catch (Exception)
            {

                return InternalServerError();
            }


        }

        public IHttpActionResult Get(int id)
        {

            try
            {
                var car = _carContext.CarModels.Where(m => m.CarManufacturerId == id).Select(m =>
                new CarModelDto
                {

                    Id = m.Id,
                    Model = m.Model
                }


                    ).ToList();

                if(car!=null)
                {
                    return Ok(car);
                }
                else
                {
                    return NotFound();
                }

                
            }
            catch (Exception)
            {

                return InternalServerError();
            }



            
        }

    }
}
