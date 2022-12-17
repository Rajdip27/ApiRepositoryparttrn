using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattenApi.DatabaseContext;
using RepositoryPattenApi.Interfaces.Manager;
using RepositoryPattenApi.Manager;
using RepositoryPattenApi.Models;
using System.Net;

namespace RepositoryPattenApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        IUserManager _userManager;
        ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
            _userManager = new UserManger(_db);
           
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var Result=_userManager.GetAll().ToList();
                if (Result == null)
                {
                    return CustomResult("Data Not Found",HttpStatusCode.NotFound);
                }
                return CustomResult("Data Loaded Successfull.", Result);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpGet]
        public IActionResult GetSarchAddress(string Address)
        {
            try
            {
                var result = _userManager.GetAddressSarch(Address);
                return CustomResult("Sarch Result",result);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpPost]
        public IActionResult UserSave(User user)
        {
            try
            {
                user.CreatedDate= DateTime.Now;
                bool IsSave=_userManager.Add(user);
                if (IsSave)
                {
                    return CustomResult("User Save Successfull.", user);
                }
                return CustomResult("User Save Failed.", HttpStatusCode.BadRequest);


            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }
        [HttpPost]
        public IActionResult UserEdit(User user)
        {
            try
            {
                if (user.Id == 0)
                {
                    return CustomResult("Id Is Missing", HttpStatusCode.NotFound);

                }
                bool IsUpdate=_userManager.Update(user);
                if (IsUpdate)
                {
                    return CustomResult("User Update Succcessfully.!",user);

                }
                return CustomResult("User Update Falied.!", HttpStatusCode.BadRequest);


            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message,HttpStatusCode.BadRequest);
            }
        }
        [HttpGet]
        public IActionResult GetAllDesc()
        {
            try
            {
                var result=_userManager.GetAll().OrderByDescending(x => x.Id).ToList();
                return CustomResult("Data Loaded Successfully..!", result);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var Result=_userManager.GetById(id);
                if(Result == null)
                {
                    return CustomResult("Data Not Found",HttpStatusCode.NotFound);
                }
                return CustomResult("Data Found",Result);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpDelete("id")]
        public IActionResult UserDelete(int id)
        {
            try
            {
                var Result = _userManager.GetById(id);
                if (Result == null)
                {
                    return CustomResult("Data not Found..!", HttpStatusCode.NotFound);

                }
                bool IsDelete=_userManager.Delete(Result);
                if (IsDelete)
                {
                    return CustomResult("User Delete SuccessFull.!", Result);
                }
                return CustomResult("User Not Found..!", HttpStatusCode.BadRequest);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public IActionResult UserSarch(string text)
        {
            try
            {
                var UserSarch=_userManager.UserSarch(text);
                return CustomResult("Sarch Result",UserSarch);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public IActionResult UserPaging(int page = 1)
        {
            try
            {
                var Result = _userManager.PagingUser(page, 5);
                return CustomResult("Paging data for page No :"+page,Result);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);

            }

        }




    }
}
