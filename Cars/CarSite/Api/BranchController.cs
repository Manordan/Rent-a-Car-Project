using CarSite.Models;
using CarSite.ViewModel;
using System;
using System.Linq;
using System.Web.Http;

namespace CarSite.Api
{


    public class BranchController : ApiController
    {
        CarContext _carContext;
        public BranchController()
        {
            _carContext = new CarContext();
        }

        public IHttpActionResult Get()
        {

            try
            {
                var branches = _carContext.Branches.Select(b =>
                new BranchDto
                {
                    Id = b.Id,
                    Name = b.Name

                }).ToList();

                return Ok(branches);
            }
            catch (Exception)
            {

                return InternalServerError();
            }


            


        }
    }
}
